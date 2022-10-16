using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class F_BusControl : MonoBehaviour
{
    private Slider Slider;
    EventInstance LevelTest;
    PLAYBACK_STATE pb;

    private VCA vca;
    public string vcaPath;
    private float vcaVolume;

    // Start is called before the first frame update
    void Start()
    {
        vca = RuntimeManager.GetVCA("vca:/" + vcaPath);
        vca.getVolume(out vcaVolume);
        Slider = GetComponent<Slider>();
        Slider.value = vcaVolume;


        if (vcaPath == "SFX")
        {
            LevelTest = RuntimeManager.CreateInstance("event:/LevelTest");
        }
        else
            LevelTest.release();
    }

    public void VolumeLevel(float SliderValue)
    {
        vca.setVolume(SliderValue);
        if (vcaPath == "SFX")
        {
            LevelTest.getPlaybackState(out pb);
            if (pb != PLAYBACK_STATE.PLAYING)
                LevelTest.start();
        }
    }

    void OnDestroy()
    {
        if (vcaPath == "SFX")
            LevelTest.release();
    }
}