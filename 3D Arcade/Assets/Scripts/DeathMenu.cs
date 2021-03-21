using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
 
    void Update()
    {
        if (Input.GetButton("Restart") == true)
        {
            SceneManager.LoadScene(1);
        }
       
        if (Input.GetButton("Main Menu") == true)
        {
            SceneManager.LoadScene(0);
        }
    }
    
}
