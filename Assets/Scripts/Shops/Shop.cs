
using AI.Inventories;//ekledim,(merbiki) proje kurtarma �abas�
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
        public ItemCategory GetFilter() {  return ItemCategory.None; }  
        public void SelectMode(bool isBuying) { }
        public bool IsBuyingMode() { return true;}
        public bool CanTransact() { return true; }
        public void ConfirmTransaction() { }

        public float TransactionTotal() { return 0; }
        public void AddToTransaction(InventoryItem item, int quantity) { }
    }

}