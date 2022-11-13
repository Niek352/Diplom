using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components.Core
{
	[Game]
	[Event(EventTarget.Self)]
	public class PositionComponent : IComponent
	{
		public Vector3 Value;
	}
}