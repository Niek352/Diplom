using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Ecs.Game.Extensions
{
	public static class GameExtensions
	{
		public static GameEntity CreateBullet(this GameContext context, 
			BulletView bulletView,
			Vector3 velocity, 
			Vector3 spawnPoint,
			float lifeTime)
		{
			var entity = context.CreateEntity();
			entity.IsBullet = true;
			entity.AddPosition(spawnPoint); 
			entity.AddVelocity(velocity);
			entity.AddLifeTime(lifeTime);
			entity.AddTime(0);
			
			var bullet = Object.Instantiate(bulletView);
			bullet.Link(entity, context);
			return entity;
		}
	}
}