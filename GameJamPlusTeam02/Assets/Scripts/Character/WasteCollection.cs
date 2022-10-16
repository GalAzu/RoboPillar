using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteCollection : MonoBehaviour
{
    [SerializeField]private float harvestTime;
    [SerializeField]private float curHarvestTime;
    [SerializeField]
    private ThirdPersonCharacter player;
    public float rayDistance;
    [SerializeField] private LayerMask rayMask;
    Icollectible collectible;

    private void Start()
    {
        player = GetComponent<ThirdPersonCharacter>();
    }
    private void Update()
    {
        var ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        RaycastHit rayHit;
        
        if (Physics.Raycast(ray, out rayHit,rayDistance,rayMask ))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.blue);
            Debug.Log("ray hit mask");
            collectible = rayHit.collider.gameObject.GetComponent<Icollectible>();
            if (collectible != null && Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (!player.onHarvest) StartCoroutine(Harvest(FinishCollecting));
            }
        }
        else Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance,Color.red);
    }
    private IEnumerator Harvest(Action action)
    {
        Debug.Log("corutine started");
        if(!player.onHarvest)
        {
            player.onHarvest = true;
            player.rb.constraints = RigidbodyConstraints.FreezeAll;
            yield return new WaitForSeconds(harvestTime);
            Debug.Log("start finish loot");
            action();
        
        }
    }

    private void FinishCollecting()
    {
        player.onHarvest = false;
        collectible.Collect();
        player.rb.constraints = RigidbodyConstraints.None;
    }
}
