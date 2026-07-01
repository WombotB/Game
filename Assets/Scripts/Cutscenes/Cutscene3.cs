using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Cutscene3 : MonoBehaviour
{
    [SerializeField] private TMP_Text Words;
    [SerializeField] private GameObject SFXM;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pause;
    [SerializeField] private Image background;
    [SerializeField] private Sprite dialogueClosed;
    [SerializeField] private Sprite dialogueOpened;
    [SerializeField] private Sprite dialogueTeeth;
    private int i = 1;
    private float timer = 1;
    private bool speaks = false;
    void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel", 3);
        speaks = true;
        timer = 0.2f;
    }

    void Update()
    {
        if (!pause.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            i++;
            switch (i)
            {
                //case 1:
                //    speaks = true;
                //    timer = 0.2f;
                //    background.sprite = dialogueOpened;
                //    Words.text = "Остался финальный раунд.";
                //    break;
                case 2:
                    speaks = false;
                    background.sprite = dialogueClosed;
                    Words.text = "Хорошо! Но сперва я хочу узнать-";
                    timer = 1;
                    break;
                case 3:
                    speaks = true;
                    timer = 0.2f;
                    Words.text = "К хренам твои знания!";
                    break;
                case 4:
                    SceneManager.LoadScene("Level3");
                    break;
            }
        }
        if (speaks)
        {
            timer-=Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0.2f;
                if (background.sprite == dialogueClosed) background.sprite = dialogueOpened;
                else if (background.sprite == dialogueOpened) background.sprite = dialogueTeeth;
                else background.sprite = dialogueClosed;
                //if (background.sprite == dialogueOpened) background.sprite = dialogueTeeth;
                //else background.sprite = dialogueOpened;
            }
        }
    }
}
