using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Toggle fullscreen1;
    [SerializeField] private Slider Soundvolume;
    [SerializeField] private Slider Musicvolume;
    [SerializeField] private GameObject SoundM;
    [SerializeField] private GameObject MusicM;
    [SerializeField] private GameObject settingsMenu;
    public void Fullscreen()
    {
        Screen.fullScreen = fullscreen1.isOn;
        if (!fullscreen1.isOn)
            PlayerPrefs.SetString("Fullscreen", "False");
        else
            PlayerPrefs.SetString("Fullscreen", "True");
    }
    public void MusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", Musicvolume.value);
        PlayerPrefs.SetString("MusicVolumeS", "True");
        MusicM.GetComponent<AudioSource>().volume = Musicvolume.value;
    }
    public void SoundVolume()
    {
        PlayerPrefs.SetFloat("SoundVolume", Soundvolume.value);
        PlayerPrefs.SetString("SoundVolumeS", "True");
        SoundM.GetComponent<AudioSource>().volume = Soundvolume.value;
    }
    void Start()
    {
        if (PlayerPrefs.GetString("Fullscreen") == "False")
        {
            Screen.fullScreen = false;
            fullscreen1.isOn = false;
        }
        else
        {
            Screen.fullScreen = true;
            fullscreen1.isOn = true;
        }
        if (PlayerPrefs.GetString("MusicVolumeS") == "True")
        {
            Musicvolume.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            Musicvolume.value = 1f;
        }
        if (PlayerPrefs.GetString("SoundVolumeS") == "True")
        {
            Soundvolume.value = PlayerPrefs.GetFloat("SoundVolume");
        }
        else
        {
            Soundvolume.value = 1f;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
    public void Close()
    {
        settingsMenu.SetActive(false);
    }
    public void Open()
    {
        settingsMenu.SetActive(true);   
    }
}