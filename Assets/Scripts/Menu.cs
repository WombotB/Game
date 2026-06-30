using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject MusicManager;
    [SerializeField] AudioClip MenuMusic;
    private float Musicvolume;
    void Start()
    {
        if (PlayerPrefs.GetString("MusicVolumeS") == "True")
        {
            Musicvolume = PlayerPrefs.GetFloat("MusicVolume");
            MusicManager.GetComponent<AudioSource>().volume = Musicvolume;
        }
        else
        {
            MusicManager.GetComponent<AudioSource>().volume = 1f;
        }
        MusicManager.GetComponent<AudioSource>().clip = MenuMusic;
        MusicManager.GetComponent<AudioSource>().Play();
    }
    public void Newgame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Gallery()
    {
        SceneManager.LoadScene("Gallery");
    }
    public void Titles()
    {
        SceneManager.LoadScene("Titles");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
