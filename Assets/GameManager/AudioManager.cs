using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
       #region Singelton
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(Instance);
    }
    #endregion
    public AudioSource audioSource;
    public AudioClip buttonSfx;
    public TextMeshProUGUI musicValue;
    //public Slider slider;
    private void Start()
    {
        //LoadAudio();
    }
    public void SetAudio(float value)
    {
        AudioListener.volume = value;
        musicValue.text = $"Music: {Mathf.Round(value * 100)}";
        //SaveAudio();
    }

    //void SaveAudio()
    //{
    //    PlayerPrefs.SetFloat("audioVolume",AudioListener.volume);
    //}

    //public void LoadAudio()
    //{
    //    if(PlayerPrefs.HasKey("audioVolume"))
    //    {
    //        AudioListener.volume=PlayerPrefs.GetFloat("audioVolume");
    //        slider.value = PlayerPrefs.GetFloat("audioVolume");
    //    }

    //    else
    //    {
    //        PlayerPrefs.SetFloat("audioVolume", 1);
    //        AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
    //        slider.value = PlayerPrefs.GetFloat("audioVolume");
    //    }
    //}
}
