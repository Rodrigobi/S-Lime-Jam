using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public float volumeMultiplier = 1.0f;

    private static VolumeSlider instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.1f;
        volumeSlider.value = 0.1f;
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderChanged);
    }

    private void OnVolumeSliderChanged(float value)
    {
        ModifyVolume(value);
    }

    public void ModifyVolume(float volume)
    {
        audioSource.volume = volume * volumeMultiplier;
    }
}
