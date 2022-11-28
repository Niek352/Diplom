using Services.SceneLoadingManager.Impl;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<SceneLoadingManager>().AsSingle().NonLazy();
		}
	}
}