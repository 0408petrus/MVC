using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Script.Scene.Gameplay
{
    public struct UpdateCoinMessage
    {
        public int Coin { get; private set; }

        public UpdateCoinMessage(int coin)
        {
            Coin = coin;
        }
    }
}
