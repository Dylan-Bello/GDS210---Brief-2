using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButton(0) || SAE.ArcadeMachine.PlayerPressingButtonStatic(SAE.ArcadeMachine.PlayerColorId.YELLOW_PLAYER, 3) == true)
        {
            PlayGame();
        }

        if (Input.GetMouseButton(0) || SAE.ArcadeMachine.PlayerPressingButtonStatic(SAE.ArcadeMachine.PlayerColorId.YELLOW_PLAYER, 4) == true)
        {
            PlayCoopGame();
        }

        if (Input.GetMouseButton(0) || SAE.ArcadeMachine.PlayerPressingButtonStatic(SAE.ArcadeMachine.PlayerColorId.YELLOW_PLAYER, 1) == true)
        {
            QuitGame();
        }

    }

    

    public void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void PlayCoopGame()
    {
        Debug.Log("Play Co-op Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}
