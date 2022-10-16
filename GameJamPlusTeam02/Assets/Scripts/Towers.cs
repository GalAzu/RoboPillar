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
        var getWasteInRadiusCast = Physics.SphereCastAll(transform.position, towerDetectionRadius, Vector3.zero, wasteMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, towerDetectionRadius);
    }
}
