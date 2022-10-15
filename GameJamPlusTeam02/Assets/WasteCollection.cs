using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteCollection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Icollectible collectible = collision.gameObject.GetComponent<Icollectible>();
        if(collectible != null)
        {
            collectible.Collect();
        }
    }
}
