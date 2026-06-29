using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip bgm;
    void Start()
    {
        GetComponent<AudioSource>().clip = bgm;
        GetComponent<AudioSource>().Play();
        if (PlayerPrefs.GetString("VolumeS") == "True")
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            GetComponent<AudioSource>().volume = 1f;
        }
    }
}
