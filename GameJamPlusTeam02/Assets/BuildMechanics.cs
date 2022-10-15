using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMechanics : MonoBehaviour
{

    public float distance;
    public float buildingCooldownTime;
    public float buildingCooldownTimer;
    private Inventory inventory;

    private void Start()
    {
        if(inventory.inventory.Contains(GetWasteInventoryItem(WasteData.wasteType.MetalSheet)) 
            && 
            GetWasteInventoryItem(WasteData.wasteType.MetalSheet).stackSize < 5 )
        {

        }
    }

    private WasteInventory GetWasteInventoryItem(WasteData.wasteType waste)
    {
        WasteInventory wasteToUse = inventory.inventory.Find(wasteParam => wasteParam.wasteData._wasteType == waste);
        return wasteToUse;
    }
    private int GetWasteInventoryItemQuantity(WasteData.wasteType waste)
    {
        WasteInventory wasteToCheck = inventory.inventory.Find(wasteParam => wasteParam.wasteData._wasteType == waste);
        return wasteToCheck.stackSize;
    }



}
