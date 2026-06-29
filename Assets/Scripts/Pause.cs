using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool pressed = false;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject settingsMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pressed && !settingsMenu.activeSelf)
        {
            pressed = true;
            OpenClose();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pressed = false;
        }
    }
    public void OpenClose()
    {
        pause.SetActive(!pause.activeSelf);
    }
}
