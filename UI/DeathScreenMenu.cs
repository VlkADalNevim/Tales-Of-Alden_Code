using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* DeathScreenMenu class for handling scenes upon death
*/
public class DeathScreenMenu : MonoBehaviour
{
    /**
    * GoToMainMenu method to handle switching scene to main menu
    * @return void
    */
    private void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /**
    * Restart method to handle restarting the game
    * @return void
    */
    private void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
