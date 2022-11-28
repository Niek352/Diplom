using Launch;
using UniRx;
using Zenject;

namespace Installers
{
	public class LaunchInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			MainThreadDispatcher.Initialize();

			Container.BindInterfacesTo<LaunchManager>().AsSingle().NonLazy();
		}
	}



}