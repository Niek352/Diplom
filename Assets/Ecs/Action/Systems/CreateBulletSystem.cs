using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.Bullet;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;


namespace Ecs.Action.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 11, "Bullet")]
	public class CreateBulletSystem : ReactiveSystem<ActionEntity>
	{
		private readonly IBulletData _bulletData;
		private readonly GameContext _game;
		
		public CreateBulletSystem(
			IBulletData bulletData,
			ActionContext action,
			GameContext game
			) : base(action)
		{
			_bulletData = bulletData;
			_game = game;
		}
		
		protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context)
			=> context.CreateCollector(ActionMatcher.CreateBullet);
		
		protected override bool Filter(ActionEntity entity)
			=> entity.HasCreateBullet;
		
		protected override void Execute(List<ActionEntity> entities)
		{
			foreach (var entity in entities)
			{
				_game.CreateBullet( 
					_bulletData.BulletView,
					entity.CreateBullet.Velocity, 
					entity.CreateBullet.SpawnPoint,
					entity.CreateBullet.LifeTime);
				
				entity.Destroy();
			}
		}
	}
}