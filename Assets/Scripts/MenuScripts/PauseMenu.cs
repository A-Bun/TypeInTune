using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenu, menuButtons, quitButtons;
    private Animator anim;

    void Start()
    {
        anim = pauseMenu.GetComponent<Animator>();
    }

    /* Update
     *   Checks if the excape key was pressed, and calls a function based on the status of
     *   the "paused" boolean.
     */
    void Update()
    {
        // checks if the excape key was pressed
        if (Input.GetKeyDown("escape"))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                Pause();
            }
        }
    }

    private void ToggleButtons(GameObject gameObj, bool status)
    {
        Button[] buttons ;
        buttons = gameObj.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = status;
        }
    }

    /* Resume
     *   Hides the pause menu, resumes the game by unfreezing time, and sets the paused
     *   to false.
     */
    public void Resume()
    {
        ToggleButtons(menuButtons, false);
        ToggleButtons(quitButtons, false);
        anim.SetBool("IsPaused", false);
        Time.timeScale = 1f;
        paused = false;
    }

    /* Pause
     *   Displays the pause menu, pauses the game by freezing time, and sets the paused
     *   boolean to true. 
     */
    void Pause()
    {
        ToggleButtons(menuButtons, true);
        ToggleButtons(quitButtons, true);
        menuButtons.SetActive(true);
        quitButtons.SetActive(false);
        anim.SetBool("IsPaused", true);
        Time.timeScale = 0f;
        paused = true;
    }

    /* Save game
     *   to be determined
     */
    public void SaveGame()
    {
        // to be determined
        Debug.Log("Saving Game...");
    }

    /* Load Game
     *   to be determined
     */
    public void LoadGame()
    {
        // to be determined
        Debug.Log("Loading Game...");
    }

    /* Settings
     *   to be determined
     */
    public void Settings()
    {
        Debug.Log("Settings appear...");
    }

    /* Quit To Main Menu
     *   Resumes the game and then quits to the main menu through the hierarchy.
     */
    public void QuitToMainMenu()
    {
        Resume();
    }

    /* Quit To Main Menu
     *   Resumes the game and then quits to the desktop.
     */
    public void QuitToDesktop()
    {
        Resume();
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
