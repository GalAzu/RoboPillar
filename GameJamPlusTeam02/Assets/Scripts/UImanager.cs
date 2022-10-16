using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI garbageInventory;
    public TextMeshProUGUI towerWaste;
    public static UImanager instance;
    private void Awake()
    {
        instance = this;
    }
}
