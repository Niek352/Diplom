using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.Bullet;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Urgent,5,"Initialize")]
	public class ReadPlayerInputSystem : IUpdateSystem
	{
		private readonly ActionContext _action;
		private readonly GameContext _game;
		private readonly IBulletData _bulletData;
		public ReadPlayerInputSystem(
			ActionContext action,
			GameContext game,
			IBulletData bulletData
		)
		{
			_action = action;
			_game = game;
			_bulletData = bulletData;
		}
		
		public void Update()
		{
			var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			if (input.x != 0 || input.y != 0)
			{
				_action.ReplacePlayerInput(input);
			}
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				_action.CreateEntity().AddCreateBullet(Vector3.forward * _bulletData.BulletSpeed, _game.PlayerEntity.Position.Value, 10f);
			}
		}
	}
}