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
	public Ecs.Game.Components.Core.LinkComponent Link { get { return (Ecs.Game.Components.Core.LinkComponent)GetComponent(GameComponentsLookup.Link); } }
	public bool HasLink { get { return HasComponent(GameComponentsLookup.Link); } }

	public void AddLink(Ecs.Views.Linkable.ILinkable newView)
	{
		var index = GameComponentsLookup.Link;
		var component = (Ecs.Game.Components.Core.LinkComponent)CreateComponent(index, typeof(Ecs.Game.Components.Core.LinkComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.View = newView;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceLink(Ecs.Views.Linkable.ILinkable newView)
	{
		var index = GameComponentsLookup.Link;
		var component = (Ecs.Game.Components.Core.LinkComponent)CreateComponent(index, typeof(Ecs.Game.Components.Core.LinkComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.View = newView;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyLinkTo(Ecs.Game.Components.Core.LinkComponent copyComponent)
	{
		var index = GameComponentsLookup.Link;
		var component = (Ecs.Game.Components.Core.LinkComponent)CreateComponent(index, typeof(Ecs.Game.Components.Core.LinkComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.View = copyComponent.View;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveLink()
	{
		RemoveComponent(GameComponentsLookup.Link);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherLink;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Link
	{
		get
		{
			if (_matcherLink == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Link);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherLink = matcher;
			}

			return _matcherLink;
		}
	}
}