using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class BGM : MonoBehaviour
{
    public EventReference musicPath;
   public EventInstance musicInst;
    // Start is called before the first frame update
    void Start()
    {
        musicInst = RuntimeManager.CreateInstance(musicPath);
        musicInst.setParameterByName("Danger", 0f, false);
        musicInst.start();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MusicParameter()
    {
        musicInst.setParameterByName("Danger", 1f, false);
    }


    private void OnDestroy()
    {
        musicInst.release();
        musicInst.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
