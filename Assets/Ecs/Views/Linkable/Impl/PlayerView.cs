using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public class PlayerView : CharacterView,
		IVelocityAddedListener
	{
		[SerializeField] private CharacterController _characterController;

		private GameEntity _self;
		public override void Link(IEntity entity, IContext context)
		{
			var e = _self = (GameEntity)entity;
			e.AddVelocityAddedListener(this);
			
			base.Link(entity, context);
		}

		public void OnVelocityAdded(GameEntity entity, Vector3 value)
		{
			_characterController.Move(value);
			_self.ReplacePosition(transform.position);
		}
	}
}