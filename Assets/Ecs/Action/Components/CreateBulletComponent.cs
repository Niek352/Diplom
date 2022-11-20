using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Components
{
	[Action]
	public class CreateBulletComponent : IComponent
	{
		public Vector3 Velocity;
		public Vector3 SpawnPoint;
		public float LifeTime;
	}
}