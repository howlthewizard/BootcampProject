using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Inventories;

namespace AI.UI.Inventories
{
    public interface IItemHolder
    {
        InventoryItem GetItem();
    }
}