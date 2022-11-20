using Db.Player.Impl;
using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Db.Bullet.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(BulletData), fileName = nameof(BulletData))]
	public class BulletData : ScriptableObject, IBulletData
	{
		[SerializeField] private BulletView _bulletView;

		public BulletView BulletView => _bulletView;
	}
}