using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Db.Bullet
{
	public interface IBulletData
	{
		BulletView BulletView { get; }
		float GravityModifier { get; }
		float BulletSpeed { get; }
		LayerMask BulletCollidedMask { get; }
	}
}