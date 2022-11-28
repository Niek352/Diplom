using Services.SceneLoadingManager;
using Zenject;

namespace Launch
{
	public class LaunchManager : IInitializable
	{
		private readonly ISceneLoadingManager _sceneLoadingManager;
		
		public LaunchManager(ISceneLoadingManager sceneLoadingManager)
		{
			_sceneLoadingManager = sceneLoadingManager;

		}
		
		public void Initialize()
		{
			_sceneLoadingManager.LoadGameFromLaunch();
		}
	}
}