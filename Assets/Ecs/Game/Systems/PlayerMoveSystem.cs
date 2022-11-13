using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game,ExecutionPriority.High,2,"Move")]
	public class PlayerMoveSystem : ReactiveSystem<ActionEntity>
	{
		private readonly GameContext _game;

		public PlayerMoveSystem(
			ActionContext action,
			GameContext game
			) : base(action)
		{
			_game = game;
		}

		protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context)
			=> context.CreateCollector(ActionMatcher.PlayerInput);

		protected override bool Filter(ActionEntity entity)
			=> entity.HasPlayerInput;
		
		protected override void Execute(List<ActionEntity> entities)
		{
			foreach (var entity in entities)
			{
				var velocity = new Vector3(entity.PlayerInput.Value.x, 0, entity.PlayerInput.Value.y) * Time.deltaTime * 5;
				_game.PlayerEntity.ReplaceVelocity(velocity);
			}
		}
	}
}