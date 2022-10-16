using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour , Icollectible
{
    public static event HandleGemCollected OnWasteCollected;
    public delegate void HandleGemCollected(WasteData wasteData);
    public WasteData wasteData;
    public Towers towerToBelong;
    private Inventory inventory;

    private void Awake()
    {
        wasteData.name = wasteData._wasteType.ToString();
        towerToBelong = GetComponentInParent<Towers>();
        inventory = FindObjectOfType<Inventory>();
    }
    public void Collect()
    {
        Destroy(gameObject);
        OnWasteCollected?.Invoke(wasteData);
        towerToBelong.wasteInRadius.Remove(this.gameObject.GetComponent<Collider>());
        towerToBelong.wasteLeftToLight--;
        inventory.curCapacity += wasteData.quantityToAdd;
        UImanager.instance.towerWaste.text = towerToBelong.wasteLeftToLight.ToString();
    }
}
