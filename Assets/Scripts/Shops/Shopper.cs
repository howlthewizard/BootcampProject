using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Shops
{
    public class Shopper : MonoBehaviour
    {
        Shop activeShop = null;

        public event Action activeShopChange;
        public void SetActiveShop(Shop shop)
        {
            activeShop = shop;
            if(activeShop != null) {
                activeShopChange();
            }
        }

        public Shop GetActiveShop()
        {
            return activeShop;
        }
    }

}