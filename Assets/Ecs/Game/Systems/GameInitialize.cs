using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.Player;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game,ExecutionPriority.Urgent,1,"Initialize")]
	public class GameInitialize : IInitializeSystem
	{
		private readonly GameContext _game;
		private readonly IPlayerData _playerData;
		
		public GameInitialize(
			GameContext game,
			IPlayerData playerData
		)
		{
			_game = game;
			_playerData = playerData;

		}
		
		public void Initialize()
		{
			var playerEntity = _game.CreateEntity();
			var player = Object.Instantiate(_playerData.PlayerView);
			playerEntity.IsPlayer = true;
			player.Link(playerEntity, _game);
		}
	}
}