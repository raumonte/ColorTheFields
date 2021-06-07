using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Main_Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject alertBox;
    
    public AudioMixer mixer;

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        LoadOptions();
    }
    public void DisplayOptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseOptionsMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void NewGameScene()
    {
        SceneManager.LoadScene("Saved Level List");
    }
    
    public void ChangeMasterVolume(float masterVolume)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20 );
    }
    public void ChangeMusicVolume(float musicVolume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
    }
    public void ChangeSFXVolume(float sfxVolume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume) * 20);
    }
    public void SaveOptions()
    {
        Debug.Log("Saving Option...");

        //Saves the player set value of the Master sounds for both the mixer and slider.
        float mixerMasterVolume;
        mixer.GetFloat("MasterVolume", out mixerMasterVolume);
        PlayerPrefs.SetFloat("MasterVolume", mixerMasterVolume);
        PlayerPrefs.SetFloat("MasterVolumeSlider", masterVolumeSlider.value);

        //Saves the player set value of the music for both the mixer and slider.
        float mixerMusicVolume;
        mixer.GetFloat("MusicVolume", out mixerMusicVolume);
        PlayerPrefs.SetFloat("MusicVolume", mixerMusicVolume);
        PlayerPrefs.SetFloat("MusicVolumeSlider", musicVolumeSlider.value);

        //Saves the player set value of the sound effects for both the mixer and the slider.
        float mixerSFXVolume;
        mixer.GetFloat("SFXVolume", out mixerSFXVolume);
        PlayerPrefs.SetFloat("SFXVolume", mixerSFXVolume);
        PlayerPrefs.SetFloat("SFXVolumeSlider", sfxVolumeSlider.value);
    }
    public void LoadOptions()
    {
        Debug.Log("Loading Option...");

        //Loads the set value of the master volume.
        float mixerMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        mixer.SetFloat("MasterVolume", mixerMasterVolume);

        //Loads the saved value of the master slider.
        float masterSliderValue = PlayerPrefs.GetFloat("MasterVolume", 1f);
        masterVolumeSlider.value = masterSliderValue;

        //Loads the saved settings of the music.
        float mixerMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        mixer.SetFloat("MusicVolume", mixerMusicVolume);

        //Loads the saved value of the slider.
        float musicSliderValue = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicVolumeSlider.value = musicSliderValue;

        //Loads the saved value of the sound effects.
        float mixerSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0f);
        mixer.SetFloat("SFXVolume", mixerSFXVolume);

        //Loads the saved value of the sound effects slider.
        float sfxSliderValue = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxVolumeSlider.value = sfxSliderValue;
    }

    public void CheckForChanges()
    {
        float savedMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        float setMasterVolume;
        mixer.GetFloat("MasterVolume", out setMasterVolume);

        //TODO: SET THE INFORMATION IN THE CODE AND EDITOR.
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float setMusicVolume;
        mixer.GetFloat("MusicVolume", out setMusicVolume);

        //TODO: SET THE INFORMATION IN THE CODE AND EDITOR.
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0f);
        float setSFXVolume;
        mixer.GetFloat("SFXVolume", out setSFXVolume);

        if (Mathf.Approximately(savedMasterVolume, setMasterVolume) && 
            Mathf.Approximately(savedMusicVolume, setMusicVolume) && 
            Mathf.Approximately(savedSFXVolume,setSFXVolume))
        {
            //The values are the same
            CloseOptionsMenu();
        }
        else
        {
            //The values are different
            ShowAlertBox();
        }
    }
    public void ShowAlertBox()
    {
        optionsMenu.SetActive(false);
        alertBox.SetActive(true);
    }
    public void CloseAlertBox()
    {
        mainMenu.SetActive(true);
        alertBox.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
