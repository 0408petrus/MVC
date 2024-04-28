using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace Example.Script.Scene.Gameplay
{
    public interface IClickGameModel : IBaseModel
    {
        public int Coin { get; }
    }
}
