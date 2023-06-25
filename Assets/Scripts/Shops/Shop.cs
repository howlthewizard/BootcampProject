using AI.Inventories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Shops
{
    public class Shop : MonoBehaviour
    {
        public class ShopItem
        {
           // InventoryItem item; Inventory script must be checked
            int availability;
            float price;
            int quantityInTransaction;
        }
        public IEnumerable<ShopItem> GetFilteredItems() { return null; }
        public void SelectFilter(ItemCategory category) { }
        public void ConfirmTransaction()
        {

        }
    }

}