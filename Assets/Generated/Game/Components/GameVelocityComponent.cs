//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity
{
	public Ecs.Game.Components.Core.VelocityComponent Velocity { get { return (Ecs.Game.Components.Core.VelocityComponent)GetComponent(GameComponentsLookup.Velocity); } }
	public bool HasVelocity { get { return HasComponent(GameComponentsLookup.Velocity); } }

	public void AddVelocity(UnityEngine.Vector3 newValue)
	{
		var index = GameComponentsLookup.Velocity;
		var component = (Ecs.Game.Components.Core.VelocityComponent)CreateComponent(index, typeof(Ecs.Game.Components.Core.VelocityComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceVelocity(UnityEngine.Vector3 newValue)
	{
		var index = GameComponentsLookup.Velocity;
		var component = (Ecs.Game.Components.Core.VelocityComponent)CreateComponent(index, typeof(Ecs.Game.Components.Core.VelocityComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyVelocityTo(Ecs.Game.Components.Core.VelocityComponent copyComponent)
	{
		var index = GameComponentsLookup.Velocity;
		var component = (Ecs.Game.Components.Core.VelocityComponent)CreateComponent(index, typeof(Ecs.Game.Components.Core.VelocityComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveVelocity()
	{
		RemoveComponent(GameComponentsLookup.Velocity);
	}
}

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherVelocity;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Velocity
	{
		get
		{
			if (_matcherVelocity == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Velocity);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherVelocity = matcher;
			}

			return _matcherVelocity;
		}
	}
}
