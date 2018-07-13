using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public const string MASTER_VOLUME_KEY = "Master_Volume";

    public const float MASTER_VOLUME_DEFAULT_VALUE = 0.5f;

    public Slider masterVolumeSlider;

    private void Awake()
    {
        loadMasterVolume();
    }

    public void setMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void saveMasterVolume()
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, AudioListener.volume);
        PlayerPrefs.Save();
    }

    public void loadMasterVolume()
    {
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
        {
            AudioListener.volume = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
            
        } else
        {
            AudioListener.volume = MASTER_VOLUME_DEFAULT_VALUE;
        }

        masterVolumeSlider.value = AudioListener.volume;
    }


}
