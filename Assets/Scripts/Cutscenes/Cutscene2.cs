using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Cutscene2 : MonoBehaviour
{
    [SerializeField] private TMP_Text Words;
    [SerializeField] private GameObject SFXM;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pause;
    [SerializeField] private Image background;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite dialogueClosed;
    [SerializeField] private Sprite dialogueOpened;
    [SerializeField] private Sprite dialogueTeeth;
    private int i = 1;
    private float timer = 1;
    private bool fires = false;
    private bool speaks = false;
    void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel", 2);
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
                //    background.sprite = sprite1;
                //    Words.text = "О, ясно, очень умно.";
                //    break;
                case 2:
                    background.sprite = sprite1;
                    Words.text = "Огнетушитель в доме с газовым отоплением.";
                    fires = true;
                    timer = 1;
                    break;
                case 3:
                    Words.text = "Иллюзия безопасности.";
                    break;
                case 4:
                    Words.text = "Что он делает в раковине?";
                    break;
                case 5:
                    fires = false;
                    speaks = true;
                    timer = 0.2f;
                    background.sprite = dialogueOpened;
                    Words.text = "До победы тебе еще две игры.";
                    break;
                case 6:
                    speaks = false;
                    background.sprite = dialogueClosed;
                    Words.text = "";
                    playButton.SetActive(true);
                    break;
            }
        }
        if (fires)
        {
            timer-=Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1;
                if(background.sprite == sprite1) background.sprite = sprite2;
                else background.sprite = sprite1;
            }
        }
        else if (speaks)
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

    public void Play()
    {
        SceneManager.LoadScene("Level2");
    }
}
