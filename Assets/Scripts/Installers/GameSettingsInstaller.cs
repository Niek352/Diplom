using Db.Bullet;
using Db.Bullet.Impl;
using Db.Player;
using Db.Player.Impl;
using UnityEngine;
using Zenject;

namespace Installers
{
	[CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
	public class GameSettingsInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private PlayerData _playerData;
		[SerializeField] private BulletData _bulletData;
		public override void InstallBindings()
		{
			Container.Bind<IPlayerData>().FromInstance(_playerData);
			Container.Bind<IBulletData>().FromInstance(_bulletData);
		}
	}
}