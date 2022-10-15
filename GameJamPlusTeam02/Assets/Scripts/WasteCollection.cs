using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteCollection : MonoBehaviour
{
    private float harvestTime;
    private float curHarvestTime;
    [SerializeField]
    private bool onHarvest;
    private Rigidbody rb;
    public float rayDistance;
    public LayerMask harvestable;
    public RaycastHit ray;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        harvestable = 6;
    }
    private void Update()
    {

        if(Physics.Raycast(transform.position, Vector3.forward * rayDistance, out ray, harvestable))
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.blue);
            HarvestWaste();
        }
        else Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
    }

    private void HarvestWaste()
    {
        Icollectible collectible = ray.collider.gameObject.GetComponent<Icollectible>();
        if (collectible != null && Input.GetKeyDown(KeyCode.Mouse1))
        {
            onHarvest = true;
            curHarvestTime = harvestTime;
            curHarvestTime -= Time.deltaTime;
            if (curHarvestTime <= 0 && onHarvest)
            {
                onHarvest = false;
                collectible.Collect();
                rb.constraints = RigidbodyConstraints.FreezePosition;

            }
            else if (!onHarvest)
                rb.constraints = RigidbodyConstraints.None;

        }
    }
}
