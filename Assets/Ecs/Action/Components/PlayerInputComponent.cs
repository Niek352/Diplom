using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Components
{
	[Action]
	[Unique]
	public class PlayerInputComponent : IComponent
	{
		public Vector2 Value;
	}
}