using System;
using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.Bullet;
using JCMG.EntitasRedux;
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
		private static readonly ListPool<RaycastCommand> RayCastPoolList = ListPool<RaycastCommand>.Instance;
		private readonly IBulletData _bulletData;
		private readonly IGroup<GameEntity> _bulletPool;
		private JobHandle _jobHandle;
		private NativeArray<RaycastHit> _raycastHit = new NativeArray<RaycastHit>(0, Allocator.Persistent);
		private NativeArray<RaycastCommand> _raycastCommands = new NativeArray<RaycastCommand>(0, Allocator.Persistent);
		
		public BulletRayCastSystem(
			IBulletData bulletData,
			GameContext game)
		{
			_bulletData = bulletData;
			_bulletPool = game.GetGroup(GameMatcher.AllOf(GameMatcher.Bullet));
		}
		
		public void Update()
		{
			var bullets = EntityListPool.Spawn();
			var tempArr = RayCastPoolList.Spawn();
			var intDeletedCount = 0;
			_bulletPool.GetEntities(bullets);
			_jobHandle.Complete();
			
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
				

				var lastPosition = b.Position.Value;
				b.Time.Value += Time.deltaTime;
				var newPosition = CalculateNewPosition(b);
				b.ReplacePosition(newPosition);
				RaycastSegment(lastPosition, newPosition, tempArr);
			}
			
			if (_raycastCommands.IsCreated)
				_raycastCommands.Dispose();
			
			if (_raycastHit.IsCreated)
				_raycastHit.Dispose();

			_raycastCommands = new NativeArray<RaycastCommand>(tempArr.ToArray(), Allocator.TempJob);
			_raycastHit = new NativeArray<RaycastHit>(bullets.Count - intDeletedCount, Allocator.TempJob);
			
			_jobHandle = RaycastCommand.ScheduleBatch(_raycastCommands, _raycastHit, 1);
			EntityListPool.Despawn(bullets);
			RayCastPoolList.Despawn(tempArr);
		}
		
		private Vector3 CalculateNewPosition(GameEntity bullet)
		{
			Vector3 gravity = Physics.gravity * Time.deltaTime * _bulletData.GravityModifier;
			return bullet.Position.Value + (bullet.Velocity.Value * Time.deltaTime) + (gravity);
		}
		
		private void RaycastSegment(Vector3 start, Vector3 end, List<RaycastCommand> raycastCommands)
		{
			var direction = end - start;
			var distance = (end - start).magnitude;
			raycastCommands.Add(new RaycastCommand(start, direction, distance, _bulletData.BulletCollidedMask));
		}
		
		public void Dispose()
		{
			_raycastHit.Dispose();
			_raycastCommands.Dispose();
		}
	}
}