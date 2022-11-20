using System;
using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;
using UniRx;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using Zenject;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game,ExecutionPriority.Normal, 10, "Bullet")]
	public class BulletRayCastSystem : IUpdateSystem, IDisposable
	{
		private static readonly ListPool<GameEntity> EntityListPool = ListPool<GameEntity>.Instance;
		
		private readonly GameContext _game;
		private readonly IGroup<GameEntity> _bulletPool;
		JobHandle _jobHandle;
		private NativeArray<RaycastHit> _raycastHit = new NativeArray<RaycastHit>(0, Allocator.Persistent);
		private NativeArray<RaycastCommand> _raycastCommands = new NativeArray<RaycastCommand>(0, Allocator.Persistent);

		public BulletRayCastSystem(GameContext game)
		{
			_game = game;
			_bulletPool = _game.GetGroup(GameMatcher.AllOf(GameMatcher.Bullet));
		}
		
		public void Update()
		{
			var bullets = EntityListPool.Spawn();
			_bulletPool.GetEntities(bullets);
			_jobHandle.Complete();
			var intDeletedCount = 0;
			for (var index = 0; index < _raycastHit.Length; index++)
			{
				var b = bullets[index];
				if (b.Time.Value >= b.LifeTime.Value)
				{
					b.Destroy();
					intDeletedCount++;
					continue;
				}
				
				var hit = _raycastHit[index];
				
				if (hit.collider != null)
				{
					b.Time.Value = 0;
					b.Position.Value = hit.point;
					b.Velocity.Value = Vector3.Reflect(b.Velocity.Value, hit.normal);
				}
			}
			
			if (_raycastCommands.IsCreated)
				_raycastCommands.Dispose();
			
			if (_raycastHit.IsCreated)
				_raycastHit.Dispose();

			_raycastCommands = new NativeArray<RaycastCommand>(bullets.Count - intDeletedCount, Allocator.TempJob);
			_raycastHit = new NativeArray<RaycastHit>(bullets.Count - intDeletedCount, Allocator.TempJob);
			
			for (var index = 0; index < _raycastHit.Length; index++)
			{
				var b = bullets[index];
				if (!b.HasPosition)
					continue;
				var lastPosition = b.Position.Value;
				b.Time.Value += Time.deltaTime;
				var newPosition = CalculateNewPosition(b);
				b.ReplacePosition(newPosition);

				RaycastSegment(lastPosition, newPosition, index, _raycastCommands);
			}
			
			_jobHandle = RaycastCommand.ScheduleBatch(_raycastCommands, _raycastHit, 1);
			EntityListPool.Despawn(bullets);
		}
		
		private Vector3 CalculateNewPosition(GameEntity bullet)
		{
			Vector3 gravity = Physics.gravity * Time.deltaTime * 0f;
			return bullet.Position.Value + (bullet.Velocity.Value * Time.deltaTime) + (gravity);
		}
		
		private void RaycastSegment(Vector3 start, Vector3 end, int index, NativeArray<RaycastCommand> raycastCommands)
		{
			var direction = end - start;
			var distance = (end - start).magnitude;
			raycastCommands[index] = new RaycastCommand(start, direction, distance);
		}
		
		public void Dispose()
		{
			_raycastHit.Dispose();
			_raycastCommands.Dispose();
		}
	}
}