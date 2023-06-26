using AI.Shops;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.UI.Shops
{
    public class ShopUI : MonoBehaviour
    {
        Shopper shopper = null;
        Shop currentShop = null;
        void Start()
        {
            shopper = GameObject.FindGameObjectWithTag("Player").GetComponent<Shopper>();
            if (shopper == null) return;

            shopper.activeShopChange += ShopChanged;
        }

        private void ShopChanged()
        {
            currentShop = shopper.GetActiveShop();
            gameObject.SetActive(currentShop != null);
        }
    }

}