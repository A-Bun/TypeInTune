using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitScript : MonoBehaviour
{
    /* Update
     *   Checks if the backspace key was pressed and quits the game.
     */
    void Update()
    {
        if (Input.GetKeyDown("backspace"))
        {
            Quit();
        }
    }

    /* Quit
     *   Prints a quit message to the console in the unity player and completely quits
     *   the game in the build.
     */
    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
