using Example.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;

namespace Example.Script.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        // Use the same name with the scene that we add in build setting
        public override string SceneName => "Gameplay";
        private ClickGameController _clickGame;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]{
            new GameplayConnector()
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]{
            new ClickGameController(),
            new SoundfxController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _clickGame.SetView(_view.ClickGameView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}
