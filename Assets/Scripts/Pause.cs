using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //[SerializeField] private GameObject SoundM;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject message;
    [SerializeField] private GameObject SFXM;
    [SerializeField] private AudioClip error;
    //[SerializeField] private GameObject player;
    private bool opened = false;
    private float timer = 0f;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                Open();
            }
            else if (!opened)
            {
                Close();
            }
        }
        opened = settingsMenu.activeSelf;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            message.SetActive(true);
        }
        else
        {
            message.SetActive(false);
        }
    }
    public void Exit()
    {
        SFXM.GetComponent<AudioSource>().clip = error;
        SFXM.GetComponent<AudioSource>().Play();
        timer = 2f;
    }
    public void Gallery()
    {
        SceneManager.LoadScene("Gallery");
    }
    public void Close()
    {
        timer = 0f;
        pauseMenu.SetActive(false);
        //if (player != null)
        //    player.GetComponent<Movement>().enabled = true;
    }
    public void Open()
    {
        pauseMenu.SetActive(true);
        //if (player != null)
        //    player.GetComponent<Movement>().enabled = false;
    }
}