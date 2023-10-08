using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanels : MonoBehaviour
{
    #region Singelton
    public static GamePanels Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(Instance);
    }
    #endregion 

    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public TextMeshProUGUI gameOverRoundText;
    public TextMeshProUGUI winRoundText;
    [HideInInspector] public bool levelCleared;
    AudioManager audioManager;
    bool status;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.Instance;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
            if (status == true)
                Time.timeScale = 0;
            else
                Time.timeScale = TimeManager.Instance.realTimeValue;
        }

        LevelCleared();
    }
    void LevelCleared()
    {
        if(levelCleared==true && EnemySpawner.Instance.currentEnemyCount<=0)
        {
            winMenu.SetActive(true);
            winRoundText.text = $"{EnemySpawner.Instance.waveIndex}";
        }

    }
    void TogglePauseMenu()
    {
        status = !status;
        pauseMenu.SetActive(status);
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }
    public void Countinue()
    {
        TogglePauseMenu();
        Time.timeScale = TimeManager.Instance.realTimeValue;
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }

    public void Menu()
    {
        TogglePauseMenu();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioManager.audioSource.PlayOneShot(audioManager.buttonSfx);
    }
}
