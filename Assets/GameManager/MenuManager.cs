using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
        SceneManager.LoadScene(2);    
    }

    public void Exit()
    {
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
        Application.Quit();
    }
}
