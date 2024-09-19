using UnityEngine;
using CustomAttributes;
using UnityEngine.UI;
using TMPro;
using System;


public class OptionsMenu : Menu
{
    [Category("Options Settings",TextAnchor.MiddleCenter)]
    [SerializeField] private Toggle fullscreenToggle;

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    [SerializeField] private TMP_Dropdown qualityDropdown;

    [SerializeField] private Toggle vsyncToggle;

    [SerializeField] private Slider volumeSlider;


    private void Start()
    {
       
        fullscreenToggle.isOn = Screen.fullScreen;

        fullscreenToggle.onValueChanged.AddListener(delegate { SetFullscreen(fullscreenToggle.isOn); });

        FillResolutionDropdown();

        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });

        FillQualityDropdown();

        qualityDropdown.onValueChanged.AddListener(delegate { SetQuality(qualityDropdown.value); });

        vsyncToggle.isOn = QualitySettings.vSyncCount == 1;

        vsyncToggle.onValueChanged.AddListener(delegate { SetVsync(vsyncToggle.isOn); });

    }

    private void SetVsync(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
    }

    private void SetResolution(int value)
    {
        Resolution resolution = Screen.resolutions[value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void SetQuality(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }

    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    private void FillResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        foreach (Resolution resolution in Screen.resolutions)
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolution.ToString()));
        }

        resolutionDropdown.RefreshShownValue();
    }

    private void FillQualityDropdown()
    {
        qualityDropdown.ClearOptions();

        foreach (string quality in QualitySettings.names)
        {
            qualityDropdown.options.Add(new TMP_Dropdown.OptionData(quality));
        }

        qualityDropdown.RefreshShownValue();
    }

}
