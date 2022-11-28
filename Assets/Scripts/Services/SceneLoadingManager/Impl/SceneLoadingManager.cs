using Extensions;
using Installers;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.SceneLoadingManager.Impl
{
	public class SceneLoadingManager : ISceneLoadingManager
	{
		public const string LAUNCH = "0.Launch";
		public const string MENU = "1.Menu";
		public const string GAME = "2.Game";
		
		public void LoadGameFromMenu()
		{
			LoadScene(GAME, MENU);
		}
		
		public void LoadGameFromLaunch()
		{
			LoadScene(GAME, LAUNCH);
		}

		public void ReloadGame()
		{
			LoadScene(GAME, GAME);
		}
		
		private void LoadScene(string sceneName, string lastScene)
		{
			SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).ToObservable().Last().Subscribe(_ =>
			{
				SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
				SceneManager.UnloadSceneAsync(lastScene).ToObservable().Last().Subscribe(_ =>
				{
					Resources.UnloadUnusedAssets().ToObservable();
					Object.FindObjectOfType<SceneContext>().Run();
				});
			});
		}
	}
}