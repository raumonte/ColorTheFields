using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
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
    public void QuitGame()
    {
        Application.Quit();
    }
}
