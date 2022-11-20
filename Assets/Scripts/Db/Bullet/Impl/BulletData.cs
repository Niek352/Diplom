using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Db.Bullet.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(BulletData), fileName = nameof(BulletData))]
	public class BulletData : ScriptableObject, IBulletData
	{
		[SerializeField] private BulletView _bulletView;

		public BulletView BulletView => _bulletView;
		[field:SerializeField] public float GravityModifier { get; private set; } = 0;
		[field:SerializeField] public float BulletSpeed { get;  private set; } = 30;
		[field:SerializeField] public LayerMask BulletCollidedMask  { get;  private set; }
	}
}