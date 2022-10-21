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
    public int wasteLeftToLight = 0;
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
                collider.GetComponent<Waste>().towerToBelong = this;
                wasteInRadius.Add(collider);
            }
        }
        towerWaste = getWasteInRadiusCastColliders.Length;
        wasteLeftToLight = getWasteInRadiusCastColliders.Length;
        UImanager.instance.towerWaste.text = wasteLeftToLight.ToString();
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
        if (wasteLeftToLight == 0)
        {
            light.intensity = Mathf.Lerp(light.intensity, lightOn, lightFadeRate); //LIGHT ON
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Light", gameObject);
        }
        else if (wasteLeftToLight > 0) 
        {
            light.intensity = Mathf.Lerp(light.intensity, lightOff, lightFadeRate);//LIGHT OFF
        } 
    }
}
