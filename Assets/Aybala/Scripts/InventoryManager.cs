using System;
using System.Collections;
using System.Collections.Generic;
using AI.Inventories;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
   public static InventoryManager Instance;
   
   public List<AllItems> _inventoryItems = new List<AllItems>(); //our inventory items 

   private void Awake()
   {
      Instance = this;
   }

   public void AddItem(AllItems item) //add items to inventory
   {
      if (!_inventoryItems.Contains(item))
      {
        _inventoryItems.Add(item); 
      }
   }
   
   public void RemoveItem(AllItems item) // remove items to inventory
   {
      if (_inventoryItems.Contains(item))
      {
         _inventoryItems.Remove(item); 
      }
   }
   
   public enum AllItems // all available inventory items in game
   {
      KeyRed,
      KeyBlue,
      KeyGreen,
   }
}
