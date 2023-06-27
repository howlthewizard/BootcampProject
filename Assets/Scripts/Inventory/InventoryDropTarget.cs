using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AI.Core.UI.Dragging;
using AI.Inventories;

namespace AI.UI.Inventories
{
  
    public class InventoryDropTarget : MonoBehaviour, IDragDestination<InventoryItem>
    {
        public void AddItems(InventoryItem item, int number)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<ItemDropper>().DropItem(item, number);
        }

        public int MaxAcceptable(InventoryItem item)
        {
            return int.MaxValue;
        }
    }
}