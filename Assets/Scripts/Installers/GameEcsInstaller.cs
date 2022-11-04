using System;
using Ecs.Action.Systems;
using Ecs.Bootstrap;
using JCMG.EntitasRedux;
using Zenject;

namespace Installers
{
	public class GameEcsInstaller : MonoInstaller
	{
		private Contexts _contexts;

		public override void InstallBindings()
		{
			_contexts = Contexts.SharedInstance;
			BindContext<GameContext>();
			BindContext<ActionContext>();
			
			InstallSystems();
			BindFeature<Feature>();
			
			Container.BindInstance(_contexts).WhenInjectedInto<Bootstrap>();
			Container.BindInterfacesTo<Bootstrap>().AsSingle().NonLazy();
		}
		private void InstallSystems()
		{
			BindSystem<ReadPlayerInputSystem>(Container);
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

			throw new Exception($"[{nameof(GameEcsInstaller)}] No context with type: {typeof(TContext).Name}");
		}

		private void BindFeature<TFeature>()
			where TFeature : Feature, new()
		{
			var mainFeature = new TFeature();
			Container.Bind<TFeature>().FromInstance(mainFeature);
		}
		
		private void BindSystem<TSystem>(DiContainer container)
		{
			container.BindInterfacesAndSelfTo<TSystem>().AsSingle();
		}
	}
}