//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;

public static class GameComponentsLookup
{
	public const int Link = 0;
	public const int LocalPosition = 1;
	public const int LookDirection = 2;
	public const int Position = 3;
	public const int Rotation = 4;
	public const int Transform = 5;
	public const int Velocity = 6;
	public const int Player = 7;
	public const int LinkRemovedListener = 8;
	public const int LocalPositionAddedListener = 9;
	public const int PositionAddedListener = 10;
	public const int RotationAddedListener = 11;
	public const int VelocityAddedListener = 12;

	public const int TotalComponents = 13;

	public static readonly string[] ComponentNames =
	{
		"Link",
		"LocalPosition",
		"LookDirection",
		"Position",
		"Rotation",
		"Transform",
		"Velocity",
		"Player",
		"LinkRemovedListener",
		"LocalPositionAddedListener",
		"PositionAddedListener",
		"RotationAddedListener",
		"VelocityAddedListener"
	};

	public static readonly System.Type[] ComponentTypes =
	{
		typeof(Ecs.Game.Components.Core.LinkComponent),
		typeof(Ecs.Game.Components.Core.LocalPositionComponent),
		typeof(Ecs.Game.Components.Core.LookDirectionComponent),
		typeof(Ecs.Game.Components.Core.PositionComponent),
		typeof(Ecs.Game.Components.Core.RotationComponent),
		typeof(Ecs.Game.Components.Core.TransformComponent),
		typeof(Ecs.Game.Components.Core.VelocityComponent),
		typeof(Ecs.Game.Components.Player.PlayerComponent),
		typeof(LinkRemovedListenerComponent),
		typeof(LocalPositionAddedListenerComponent),
		typeof(PositionAddedListenerComponent),
		typeof(RotationAddedListenerComponent),
		typeof(VelocityAddedListenerComponent)
	};

	public static readonly Dictionary<Type, int> ComponentTypeToIndex = new Dictionary<Type, int>
	{
		{ typeof(Ecs.Game.Components.Core.LinkComponent), 0 },
		{ typeof(Ecs.Game.Components.Core.LocalPositionComponent), 1 },
		{ typeof(Ecs.Game.Components.Core.LookDirectionComponent), 2 },
		{ typeof(Ecs.Game.Components.Core.PositionComponent), 3 },
		{ typeof(Ecs.Game.Components.Core.RotationComponent), 4 },
		{ typeof(Ecs.Game.Components.Core.TransformComponent), 5 },
		{ typeof(Ecs.Game.Components.Core.VelocityComponent), 6 },
		{ typeof(Ecs.Game.Components.Player.PlayerComponent), 7 },
		{ typeof(LinkRemovedListenerComponent), 8 },
		{ typeof(LocalPositionAddedListenerComponent), 9 },
		{ typeof(PositionAddedListenerComponent), 10 },
		{ typeof(RotationAddedListenerComponent), 11 },
		{ typeof(VelocityAddedListenerComponent), 12 }
	};

	/// <summary>
	/// Returns a component index based on the passed <paramref name="component"/> type; where an index cannot be found
	/// -1 will be returned instead.
	/// </summary>
	/// <param name="component"></param>
	public static int GetComponentIndex(IComponent component)
	{
		return GetComponentIndex(component.GetType());
	}

	/// <summary>
	/// Returns a component index based on the passed <paramref name="componentType"/>; where an index cannot be found
	/// -1 will be returned instead.
	/// </summary>
	/// <param name="componentType"></param>
	public static int GetComponentIndex(Type componentType)
	{
		return ComponentTypeToIndex.TryGetValue(componentType, out var index) ? index : -1;
	}
}