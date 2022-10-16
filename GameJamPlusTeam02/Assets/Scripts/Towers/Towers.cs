using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Towers : MonoBehaviour
{
    [SerializeField] private float towerDetectionRadius;
    [SerializeField] public List<Collider> wasteInRadius = new List<Collider>();
    [SerializeField] private LayerMask wasteMask;
    [SerializeField] new Light light;
    [SerializeField]
    private float lightOff, lightOn;
    [SerializeField]private float lightFadeRate;
    public int wasteLeftToLight;
    public int towerWaste;
    private TextMeshProUGUI towerUI;
    private bool towerIsLit;

    private void Start()
    {
        light = GetComponent<Light>();
        Collider[] getWasteInRadiusCastColliders = Physics.OverlapSphere(transform.position, towerDetectionRadius, wasteMask);
        foreach(var collider in getWasteInRadiusCastColliders)
        {
            if(collider != null)
            {
                wasteInRadius.Add(collider);
            }
            else if(collider.tag == "Player")
            {
                ShowUI();
            }
        }
        towerWaste = getWasteInRadiusCastColliders.Length;
        wasteLeftToLight = getWasteInRadiusCastColliders.Length;
    }

    private void ShowUI()
    {
        if (!towerIsLit)
            towerUI.text = wasteLeftToLight.ToString() + "/" + towerWaste;
        else towerUI.text = "Tower is Lit!";
    }

    private void Update()
    {
        TurnLightOnAndOff();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, towerDetectionRadius);
        
    }
    private void TurnLightOnAndOff()
    {
        if (wasteInRadius.Count > 3) light.intensity = Mathf.Lerp(light.intensity, lightOn, lightFadeRate);
        else if (wasteInRadius.Count < 3) light.intensity = Mathf.Lerp(light.intensity, lightOff, lightFadeRate);
    }

}
