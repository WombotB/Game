using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene1 : MonoBehaviour
{
    [SerializeField] private TMP_Text Words;
    [SerializeField] private GameObject SFXM;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pause;
    [SerializeField] private Image background;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;
    [SerializeField] private Sprite dialogueClosed;
    [SerializeField] private Sprite dialogueOpened;
    [SerializeField] private Sprite dialogueTeeth;
    private int i = 1;
    private float timer = 1;
    private bool speaks = false;
    void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel", 1);
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
                //    break;
                case 2:
                    background.sprite = sprite2;
                    break;
                case 3:
                    background.sprite = sprite3;
                    Words.text = "Что? Цветочек?... Кто это сделал?..";
                    break;
                case 4:
                    background.sprite = sprite4;
                    Words.text = "Это что, нейрослоп?";
                    break;
                case 5:
                    background.sprite = dialogueClosed;
                    Words.text = "...";
                    break;
                case 6:
                    Words.text = "Верни нейрослоп…";
                    break;
                case 7:
                    speaks = true;
                    timer = 0.2f;
                    Words.text = "Поздно.";
                    break;
                case 8:
                    speaks = false;
                    background.sprite = dialogueClosed;
                    Words.text = "Ты мой лоб разрисовала?";
                    break;
                case 9:
                    speaks = true;
                    timer = 0.2f;
                    background.sprite = dialogueOpened;
                    Words.text = "Не уверена.";
                    break;
                case 10:
                    Words.text = "Обыграешь меня в карты - скажу.";
                    break;
                case 11:
                    speaks = false;
                    background.sprite = dialogueClosed;
                    Words.text = "";
                    playButton.SetActive(true);
                    break;
            }
        }
        if (speaks)
        {
            timer -= Time.deltaTime;
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
        SceneManager.LoadScene("Level1");
    }
}
