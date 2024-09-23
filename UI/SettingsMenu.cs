using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/**
* SettingsMenu class for handling game resolution and fullscreen mode
*/
public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    /**
    * Start is called before the first frame update.
    * This method populates the resolution dropdown menu with available screen resolutions.
    * It sets the current resolution as the default option and refreshes the shown value.
    */
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    /**
    * SetResolution sets the screen resolution based on the selected option.
    * @param resolutionIndex The index of the selected screen resolution in the resolutions array.
    */
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /**
    * SetFullscreen sets the game to fullscreen mode or windowed mode.
    * @param isFullscreen Whether or not to enable fullscreen mode.
    */
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
