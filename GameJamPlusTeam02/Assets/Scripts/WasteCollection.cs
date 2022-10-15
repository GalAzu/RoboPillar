using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteCollection : MonoBehaviour
{
    [SerializeField]private float harvestTime;
    [SerializeField]private float curHarvestTime;
    [SerializeField]
    private bool onHarvest;
    private Rigidbody rb;
    public float rayDistance;
    [SerializeField] private LayerMask rayMask;
    Icollectible collectible;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        var ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        RaycastHit rayHit;
        
        if (Physics.Raycast(ray, out rayHit,rayDistance,rayMask ))
        {
            Debug.Log("ray hit mask");
            collectible = rayHit.collider.gameObject.GetComponent<Icollectible>();
            if (collectible != null && Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (!onHarvest) StartCoroutine(Harvest(FinishCollecting));
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance);
    }
    private IEnumerator Harvest(Action action)
    {
        Debug.Log("corutine started");
        if(!onHarvest)
        {
            onHarvest = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            yield return new WaitForSeconds(harvestTime);
            Debug.Log("start finish loot");
            action();
        }
    }

    private void FinishCollecting()
    {
        onHarvest = false;
        collectible.Collect();
        rb.constraints = RigidbodyConstraints.None;
    }
}
