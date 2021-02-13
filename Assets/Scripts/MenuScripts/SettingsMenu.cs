using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    /* Start
     *   Saves, into an array, all the possible resolutions for the monitor the game is being played on,
     *   adds them to a dropdown list, and saves the index of the current resolution of the monitor.
     */
    private void Start()
    {
        // saves the possible resolutions for the monitor
        resolutions = Screen.resolutions;

        // clears default dropdown options
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            // only saves resolutions of 60 Hz and above
            if (resolutions[i].refreshRate >= 60)
            {
                /* formats a string for each resolution 
                    (resolutions must be converted to strings in order to be added to the dropdown menu)
                */
                string option = resolutions[i].width + " x " + resolutions[i].height + " @ " +
                    resolutions[i].refreshRate + " Hz";

                // adds the newly formatted string to the string list
                options.Add(option);
            }

            // compares each resolution to the current resolution of the window
            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        // adds all the resolution strings to the resolution dropdown
        resolutionDropdown.AddOptions(options);
        
        // sets the default game resolution to the monitor's current resolution 
        resolutionDropdown.value = currentResolutionIndex;

        // displays the current resolution
        resolutionDropdown.RefreshShownValue();
    }

    /* Set Resolution
     *   Parameter: int resolutionIndex
     *   Sets the game's resolution to the passed in index
     */
    public void SetResolution( int resolutionIndex)
    {
        // stores the passed in resolution
        Resolution resolution = resolutions[resolutionIndex];

        // sets the game's resolution to the passed in resolution
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /* Set Fullscreen
     *   Parameter: boolean isFullscreen
     *   Sets the game to fullscreen mode if the passed in bool is true, otherwise sets
     *   the game to windowed mode.
     */
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
