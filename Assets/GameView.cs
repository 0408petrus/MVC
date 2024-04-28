using Example.Boot;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Scenes.Gameplay
{
    public class GameView : BaseSceneView
    {
        [SerializeField]
        private Button _homeButton;
        [SerializeField]
        private Button _restartButton;


        public void Init(UnityAction onHome, UnityAction onRestart)
        {
            _homeButton.onClick.RemoveAllListeners();
            _homeButton.onClick.AddListener(onHome);

            _restartButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(onRestart);
        }

    }
}
