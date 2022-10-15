using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour , Icollectible
{
    public static event HandleGemCollected OnWasteCollected;
    public delegate void HandleGemCollected(WasteData wasteData);
    public WasteData wasteData;


    public void Collect()
    {
        Destroy(gameObject);
        OnWasteCollected?.Invoke(wasteData);
    }

}
