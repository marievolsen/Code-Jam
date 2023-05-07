using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    //Based on https://www.youtube.com/watch?v=tEsuLTpz_DU

    [SerializeField] private Slider _slider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            _slider.value = PlayerPrefs.GetFloat("Volume");
        }

        SoundManager.Instance.ChangeMasterVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
        _slider.onValueChanged.AddListener(val => PlayerPrefs.SetFloat("Volume", val));
    }
}