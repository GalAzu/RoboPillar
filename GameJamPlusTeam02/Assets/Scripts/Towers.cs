using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        wasteLeftToLight = getWasteInRadiusCastColliders.Length;
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
