using Zenject;

namespace Installers
{
	public static class SystemHelperInstaller 
	{
		public static void BindSystem<TSystem>(DiContainer container)
		{
			container.BindInterfacesAndSelfTo<TSystem>().AsSingle();
		}
	}
}