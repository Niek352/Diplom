using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components.Core
{
	[Game]
	[Event(EventTarget.Self)]
	public class RotationComponent : IComponent
	{
		public Quaternion Value;
	}
}