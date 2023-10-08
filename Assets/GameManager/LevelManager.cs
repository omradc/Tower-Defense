using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
    }
    public void LevelSelect(int build›dex)
    {
        SceneManager.LoadScene(build›dex);
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }
}
