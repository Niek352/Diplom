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
using Ecs.Action.Systems;
using Ecs.Bootstrap;
using Ecs.Game.Systems;
using JCMG.EntitasRedux;
using Installers;
using Zenject;

	public static class GameEcsInstaller
	{
		public static void InstallSystems(DiContainer container)
		{
			SystemHelperInstaller.BindSystem<GameInitialize>(container);
            SystemHelperInstaller.BindSystem<PlayerMoveSystem>(container);
            SystemHelperInstaller.BindSystem<ReadPlayerInputSystem>(container);
            SystemHelperInstaller.BindSystem<BulletRayCastSystem>(container);
            SystemHelperInstaller.BindSystem<CreateBulletSystem>(container);
		}
	}
