using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class EnemySteps : MonoBehaviour
{
    public EventInstance spiderInst;
    public PLAYBACK_STATE spiderPB;


    // Start is called before the first frame update
    void Start()
    {
        spiderInst = RuntimeManager.CreateInstance("event:/Enemy steps");
    }

    // Update is called once per frame
    void Update()
    {
        spiderInst.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        spiderInst.getPlaybackState(out spiderPB);


    }


    public void PlaySteps()
    {
        if (spiderPB != PLAYBACK_STATE.PLAYING)
        {
            spiderInst.start();

        }
    }

    private void OnDestroy()
    {
        spiderInst.release();
        spiderInst.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
