using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
* MainMenuController class for handling scenes in main menu
*/
public class MainMenuController : MonoBehaviour
{
    /**
    * StartNewGame method to handle starting the game
    * @return void
    */
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    /**
    * LoadGame method to handle loading the game
    * @return void
    */
    public void LoadGame()
    {
        DataPersisteneManager.instance.LoadGame();
    }

    /**
    * ExitGame method to handle exiting the game
    * @return void
    */
    public void ExitGame()
    {
        Application.Quit();
    }
}
