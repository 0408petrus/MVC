using Example.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;

namespace Scenes.Gameplay
{
    public class GameLauncher:SceneLauncher<GameLauncher, GameView>
    {
        // Use the same name with the scene that we add in build setting
        public override string SceneName => "Gameplay";

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {
            return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.Init(BackToHome, Restart);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        private void BackToHome()
        {
            SceneLoader.Instance.LoadScene("Home");
        }

        private void Restart()
        {
            SceneLoader.Instance.RestartScene();
        }
    }
}
