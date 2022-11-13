using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public class PlayerView : CharacterView,
		IVelocityAddedListener
	{
		[SerializeField] private CharacterController _characterController;
		
		public override void Link(IEntity entity, IContext context)
		{
			var e = (GameEntity)entity;
			e.AddVelocityAddedListener(this);

			base.Link(entity, context);
		}

		public void OnVelocityAdded(GameEntity entity, Vector3 value)
		{
			_characterController.Move(value);
		}
	}
}