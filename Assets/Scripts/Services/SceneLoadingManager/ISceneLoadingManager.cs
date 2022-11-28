namespace Services.SceneLoadingManager
{
	public interface ISceneLoadingManager
	{
		void LoadGameFromMenu();
		void LoadGameFromLaunch();
		void ReloadGame();
	}
}