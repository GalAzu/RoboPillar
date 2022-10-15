using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMechanics : MonoBehaviour
{

    public float distance;
    public float buildingCooldownTime;
    public float buildingCooldownTimer;
    private Inventory inventory;



    private WasteInventory GetWasteInventoryItem(WasteData.wasteType waste)
    {
        WasteInventory wasteToUse = inventory.inventory.Find(wasteParam => wasteParam.wasteData._wasteType == waste);
        return wasteToUse;
    }
    private int GetWasteInventoryItemQuantity(WasteData.wasteType waste)
    {
        var wasteToCheck = inventory.inventory.Find(wasteParam => wasteParam.wasteData._wasteType == waste);
        return wasteToCheck.stackSize;
    }

}
