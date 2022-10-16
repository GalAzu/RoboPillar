using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
    
{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayConfirmSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI");
    }

    public void PlayBackSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI Back");
    }
}
