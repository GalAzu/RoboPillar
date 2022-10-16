using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightRotationFollow : MonoBehaviour
{
    public Transform spider;
    private void Update()
    {
        transform.rotation = spider.rotation;
    }
}
