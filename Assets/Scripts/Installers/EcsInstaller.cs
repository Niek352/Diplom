using System;
using Ecs.Action.Systems;
using Ecs.Bootstrap;
using Ecs.Game.Systems;
using JCMG.EntitasRedux;
using Zenject;

namespace Installers
{
	public class EcsInstaller : MonoInstaller
	{
		private Contexts _contexts;

		public override void InstallBindings()
		{
			_contexts = Contexts.SharedInstance;
			BindContext<GameContext>();
			BindContext<ActionContext>();
			
			InstallSystems();
			
			BindEventSystem<GameEventSystems>();
			
			BindFeature<Feature>();
			
			Container.BindInstance(_contexts).WhenInjectedInto<Bootstrap>();
			Container.BindInterfacesTo<Bootstrap>().AsSingle().NonLazy();
		}
		private void InstallSystems()
		{
			GameEcsInstaller.InstallSystems(Container);
		}
		
		protected void BindEventSystem<TEventSystem>()
			where TEventSystem : Feature
		{
			Container.BindInterfacesTo<TEventSystem>().AsSingle().WithArguments(_contexts);
		}
		
		private void BindContext<TContext>()
			where TContext : IContext
		{
			foreach (var ctx in _contexts.AllContexts)
				if (ctx is TContext context)
				{
					Container.BindInterfacesAndSelfTo<TContext>().FromInstance(context).AsSingle();
					return;
				}

			throw new Exception($"[{nameof(EcsInstaller)}] No context with type: {typeof(TContext).Name}");
		}

		private void BindFeature<TFeature>()
			where TFeature : Feature, new()
		{
			var mainFeature = new TFeature();
			Container.Bind<TFeature>().FromInstance(mainFeature);
		}
	}
}