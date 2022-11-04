using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Systems
{
	public class ReadPlayerInputSystem : IUpdateSystem
	{
		private readonly ActionContext _action;
		public ReadPlayerInputSystem(
			ActionContext action
			)
		{
			_action = action;
		}
		
		public void Update()
		{
			var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			if (input.x != 0 || input.y != 0)
			{
				_action.ReplacePlayerInput(input);
			}
		}
	}
}