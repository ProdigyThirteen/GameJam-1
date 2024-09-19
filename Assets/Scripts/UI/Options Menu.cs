using UnityEngine;
using CustomAttributes;
using UnityEngine.UI;
using TMPro;
using System;


public class OptionsMenu : Menu
{
    [Category("Tabs", TextAnchor.MiddleCenter)]
    [SerializeField] private SettingsTab videoSettingsPanel;

    [SerializeField] private SettingsTab audioSettingsPanel;

    [Serializable]
    struct SettingsTab
    {
        public RectTransform panel;
        public Button button;
        public RectTransform buttonRect;
    }




    [Category("Video Settings",TextAnchor.MiddleCenter)]
    [SerializeField] private Toggle fullscreenToggle;

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    [SerializeField] private TMP_Dropdown qualityDropdown;

    [SerializeField] private Toggle vsyncToggle;

    [Category("Audio Settings", TextAnchor.MiddleCenter)]

    [SerializeField] private Slider masterVolumeSlider;

    [SerializeField] private Slider musicVolumeSlider;

    [SerializeField] private Slider sfxVolumeSlider;

    [SerializeField] private Slider UIVolumeSlider;

    private void Start()
    {
       
        fullscreenToggle.isOn = Screen.fullScreen;

        fullscreenToggle.onValueChanged.AddListener(delegate { SetFullscreen(fullscreenToggle.isOn); });

        FillResolutionDropdown();

        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });

        FillQualityDropdown();

        qualityDropdown.onValueChanged.AddListener(delegate { SetQuality(qualityDropdown.value); });

        vsyncToggle.isOn = QualitySettings.vSyncCount == 0;

        vsyncToggle.onValueChanged.AddListener(delegate { SetVsync(vsyncToggle.isOn); });

        videoSettingsPanel.button.onClick.AddListener(delegate { EnablePanel(videoSettingsPanel.panel, videoSettingsPanel.buttonRect); });
        
        audioSettingsPanel.button.onClick.AddListener(delegate { EnablePanel(audioSettingsPanel.panel, audioSettingsPanel.buttonRect); });

        masterVolumeSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetMasterVolume(masterVolumeSlider.value); });
        masterVolumeSlider.value = AudioManager.Instance.GetMasterVolume();

        musicVolumeSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetMusicVolume(musicVolumeSlider.value); });
        musicVolumeSlider.value = AudioManager.Instance.GetMusicVolume();

        sfxVolumeSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetEffectVolume(sfxVolumeSlider.value); });
        sfxVolumeSlider.value = AudioManager.Instance.GetEffectVolume();

        UIVolumeSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetUIVolume(UIVolumeSlider.value); });
        UIVolumeSlider.value = AudioManager.Instance.GetUIVolume();




    }

    private void EnablePanel(RectTransform panelRect, RectTransform buttonRect)
    {
        Debug.Log("Enable Panel");

        videoSettingsPanel.panel.gameObject.SetActive(false);
        audioSettingsPanel.panel.gameObject.SetActive(false);

        panelRect.gameObject.SetActive(true);

        //Bring button to front
        buttonRect.SetAsLastSibling();

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
