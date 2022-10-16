using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField] private float towerDetectionRadius;
    [SerializeField] private List<Collider> wasteInRadius = new List<Collider>();
    [SerializeField] private LayerMask wasteMask;

    private void Start()
    {
        Collider[] getWasteInRadiusCastColliders = Physics.OverlapSphere(transform.position, towerDetectionRadius, wasteMask);
        foreach(var collider in getWasteInRadiusCastColliders)
        {
            if(collider != null)
            {
                wasteInRadius.Add(collider);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, towerDetectionRadius);
        
    }
}
