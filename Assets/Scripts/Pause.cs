using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenu;
    private bool opened = false;

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
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Close()
    {
        pauseMenu.SetActive(false);
    }
    public void Open()
    {
        pauseMenu.SetActive(true);
    }
}