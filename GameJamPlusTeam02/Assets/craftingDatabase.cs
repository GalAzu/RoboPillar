using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipe
{
    public WasteInventory wasteItem;
    public int itemQty;
    public GameObject objectToSpawn;

    public GameObject(WasteInventory _wasteItem , int _itemQty)
    {
        wasteItem = _wasteItem;
        itemQty = _itemQty;
    }
}
