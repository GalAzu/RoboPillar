using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMechanics : MonoBehaviour
{

    public float distance;
    public float buildingCooldownTime;
    public float buildingCooldownTimer;
    private Inventory inventory;
    public Dictionary<int, WasteInventory> wasteQuantityToBuild = new Dictionary<int, WasteInventory>();

    private void Start()
    {
        buildingCooldownTimer = buildingCooldownTime;
    }
    // Update is called once per frame
    void Update()
    {
        buildingCooldownTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && buildingCooldownTimer <= 0)
        {
            buildingCooldownTimer = buildingCooldownTime;
            CreateObjectAtPlace();
        }
    }
    private void CreateObjectAtPlace()
    {
        Vector3 transformToBuild = transform.TransformPoint(Vector3.forward * distance);

        /* Instantiate(objToBuild, transformToBuild, transform.rotation);
     }
     public void ObjectToBuild(GameObject object)
         ו
     {

     }*/
    }
}
