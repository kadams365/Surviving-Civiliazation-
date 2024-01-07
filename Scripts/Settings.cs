using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;

public class Settings : MonoBehaviour
{
    GameData saveData = new GameData();

    public GameObject Menu;
    public GameObject Globe;

    // Loading Screen
    public GameObject loadingScreen;

    public AudioMixer audioMixer;
    public Slider MusicSlider;
    public Slider EffectsSlider;
    public Slider SoundSlider;

    public TMP_Dropdown QualityDropDown;

    public TextMeshProUGUI VsyncText;
    public TextMeshProUGUI TripleBufferingText;
    public TextMeshProUGUI FpsText;
    public GameObject FPS_counter;
    public TextMeshProUGUI antiAliasingText;

    public string sceneName;

    public void LoadingInitialSettings()
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Get the name of the current scene
        sceneName = currentScene.name;

        saveData = SaveSystem.instance.LoadGame();

        SoundSlider.value = saveData.masterVol;
        MusicSlider.value = saveData.musicVol;
        EffectsSlider.value = saveData.effectsVol;

        if (saveData.vsync)
        {
            VsyncText.text = "Off";
            Application.targetFrameRate = 500;
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            VsyncText.text = "On";
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            QualitySettings.vSyncCount = 1;
        }

        if (saveData.triplebuffering)
        {
            TripleBufferingText.text = "Off";
            QualitySettings.maxQueuedFrames = 2;
        }
        else
        {
            TripleBufferingText.text = "On";
            QualitySettings.maxQueuedFrames = 3;
        }

        if (saveData.fps)
        {
            FpsText.text = "Off";
            FPS_counter.SetActive(false);
        }
        else
        {
            FpsText.text = "On";
            FPS_counter.SetActive(true);
        }

        if (saveData.antiAliasing == 1)
        {
            QualitySettings.antiAliasing = 2;
        }
        else if (saveData.antiAliasing == 2)
        {
            QualitySettings.antiAliasing = 4;
        }
        else if (saveData.antiAliasing == 3)
        {
            QualitySettings.antiAliasing = 8;
        }
        else
        {
            QualitySettings.antiAliasing = 0;
        }

        if(QualitySettings.antiAliasing > 0)
        {
            antiAliasingText.text = QualitySettings.antiAliasing + "x";
        }
        else
        {
            antiAliasingText.text = "Off";
        }

        if(saveData.qualityLevel == 0)
        {
            QualitySettings.SetQualityLevel(0);
        }
        else if(saveData.qualityLevel == 1)
        {
            QualitySettings.SetQualityLevel(1);
        }
        else if (saveData.qualityLevel == 2)
        {
            QualitySettings.SetQualityLevel(2);
        }
        else if (saveData.qualityLevel == 3)
        {
            QualitySettings.SetQualityLevel(3);
        }

        QualityDropDown.value = QualitySettings.GetQualityLevel();

        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void VsyncOnOff()
    {
        if(saveData.vsync)
        {
            saveData.vsync = false;
            VsyncText.text = "On";
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            saveData.vsync = true;
            VsyncText.text = "Off";
            Application.targetFrameRate = 500;
            QualitySettings.vSyncCount = 0;
        }

        saveData.ChangeVsync(saveData.vsync);
        print("vSync change: " + QualitySettings.vSyncCount);
    }

    public void TripleBufferingOnOff()
    {
        if(saveData.triplebuffering)
        {
            saveData.triplebuffering = false;
            TripleBufferingText.text = "On";
            QualitySettings.maxQueuedFrames = 3;
        }
        else
        {
            saveData.triplebuffering = true;
            TripleBufferingText.text = "Off";
            QualitySettings.maxQueuedFrames = 2;
        }
        saveData.ChangeBuffering(saveData.triplebuffering);
        print("Number of queued frames: " + QualitySettings.maxQueuedFrames);
    }

    public void FpsOnOff()
    {
        if (saveData.fps)
        {
            saveData.fps = false;
            FpsText.text = "On";
            FPS_counter.SetActive(true);
        }
        else
        {
            saveData.fps = true;
            FpsText.text = "Off";
            FPS_counter.SetActive(false);
        }
        saveData.ChangeFPS(saveData.fps);
    }

    public void AntiAliasingOnOff()
    {
        if (saveData.antiAliasing == 0)
        {
            saveData.antiAliasing++;
            QualitySettings.antiAliasing = 2;
        }
        else if (saveData.antiAliasing == 1)
        {
            saveData.antiAliasing++;
            QualitySettings.antiAliasing = 4;
        }
        else if (saveData.antiAliasing == 2)
        {
            saveData.antiAliasing++;
            QualitySettings.antiAliasing = 8;
        }
        else
        {
            saveData.antiAliasing = 0;
            QualitySettings.antiAliasing = 0;
        }

        antiAliasingText.text = QualitySettings.antiAliasing + "x";

        saveData.ChangeAntiAliasing(saveData.antiAliasing);
        print("AntiAliasing Change: " + QualitySettings.antiAliasing);
    }

    public void SaveSettings()
    {
        SaveSystem.instance.SaveGame(saveData);
    }

    IEnumerator AutoSaveSettings()
    {
        while(gameObject.activeSelf){
            yield return new WaitForSeconds(20);
            SaveSystem.instance.SaveGame(saveData);
            print("Settings auto saved");
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && sceneName == "Game")
        {
            SettingsInGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && sceneName == "Menu" && gameObject.activeSelf)
        {
            OpenSettings();
        }
    }

    public void OpenSettings()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Menu.SetActive(!Menu.activeSelf);
        Globe.SetActive(!Globe.activeSelf);

        //StartCoroutine(AutoSaveSettings());
    }

    void OnDisable()
    {
        SaveSettings();
    }

    public void SettingsInGame()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        if (gameObject.activeSelf == true)
        {
            SaveSettings();
        }
        if (gameObject.activeSelf == false)
        {
            SaveSettings();
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("master", volume);
        saveData.ChangeMasterVolume(volume);
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("music", volume);
        saveData.ChangeMusicVolume(volume);
    }

    public void SetEffects(float volume)
    {
        audioMixer.SetFloat("effects", volume);
        saveData.ChangeEffectsVolume(volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        saveData.ChangeQualityLevel(qualityIndex);
        print("Quality Change: " + QualitySettings.GetQualityLevel());
    }

    public void setFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void GoToMenu()
    {
        StartCoroutine(LoadMenuAsyncScene());
    }

    IEnumerator LoadMenuAsyncScene()
    {
        loadingScreen.SetActive(true);
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName("Menu"));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
