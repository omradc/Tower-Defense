using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour
{
    AudioManager audioManager;
    void Start()
    {
        audioManager = AudioManager.Instance;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }
    public void InfoMenu()
    {
        SceneManager.LoadScene(1);
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }

}
