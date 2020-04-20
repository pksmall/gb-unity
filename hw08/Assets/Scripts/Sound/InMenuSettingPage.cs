using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System;


public class InMenuSettingPage : MonoBehaviour
{
    #region Fields
    public SoundVolumeSliderSettingsData[] SoundVolumesSettings;

    public Button cancelBtn;
    public Button savebackBtn;
    public GameObject visualPart;
    public AudioMixer Mixer;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        cancelBtn.onClick.AddListener(Cancel);
        savebackBtn.onClick.AddListener(SaveBack);

        foreach (SoundVolumeSliderSettingsData soundVolumeSetting in SoundVolumesSettings)
        {
            soundVolumeSetting.Init(Mixer);
        }
    }
    #endregion

    #region Methods
    [Serializable]
    public class SoundVolumeSliderSettingsData
    {
        public Slider VolumeSlider;
        public TextMeshProUGUI VolumeText;
        public string VolumeParamNameInMixer;
        private AudioMixer _Mixer;
        protected string origBG_Text;

        public void SliderValueChanged(float param)
        {
            _Mixer.SetFloat(VolumeParamNameInMixer, param);
            VolumeText.text = origBG_Text;
            VolumeText.text = VolumeText.text + " " + param.ToString();
        }

        public void Init(AudioMixer Mixer)
        {
            float currentBGVolume;
            _Mixer = Mixer;

            origBG_Text = VolumeText.text;
            _Mixer.GetFloat(VolumeParamNameInMixer, out currentBGVolume);
            VolumeSlider.value = currentBGVolume;
            VolumeText.text = VolumeText.text + " " + currentBGVolume.ToString();

            VolumeSlider.onValueChanged.AddListener(SliderValueChanged);
        }
    }

    private void Cancel()
    {
        visualPart.SetActive(false);
    }

    private void SaveBack()
    {
        visualPart.SetActive(false);
    }
    #endregion
}
