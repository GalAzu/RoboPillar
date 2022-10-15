using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<WasteInventory> inventory = new List<WasteInventory>();
    public Dictionary<WasteData, WasteInventory> wasteDictionary = new Dictionary<WasteData, WasteInventory>();
    private void OnEnable()
    {
        Waste.OnWasteCollected += AddToInventory;
    }
    private void OnDisable()
    {
        Waste.OnWasteCollected -= AddToInventory;
    }
    public void AddToInventory(WasteData wasteData)
    {
        if(wasteDictionary.TryGetValue(wasteData , out WasteInventory wasteItem))
        {
            wasteItem.AddToStack();
        }
        WasteInventory newWaste = new WasteInventory(wasteData);
        inventory.Add(newWaste);
        wasteDictionary.Add(wasteData, newWaste);
    }
    public void RemoveFromInventory(WasteData wasteData)
    {
        if (wasteDictionary.TryGetValue(wasteData , out WasteInventory wasteItem))
        {
            wasteItem.RemoveFromStack();
            if(wasteItem.stackSize == 0)
            {
                inventory.Remove(wasteItem);
                wasteDictionary.Remove(wasteData);
            }
        }

    }
}
