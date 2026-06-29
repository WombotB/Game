using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Cutscene1 : MonoBehaviour
{
    [SerializeField] private GameObject DialogueW;
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

    void Start()
    {

    }

    void Update()
    {
        if (!pause.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0)))
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
                    background.sprite = dialogueOpened;
                    Words.text = "Поздно.";
                    break;
                case 8:
                    background.sprite = dialogueClosed;
                    Words.text = "Ты мой лоб разрисовала?";
                    break;
                case 9:
                    background.sprite = dialogueOpened;
                    Words.text = "Не уверена.";
                    break;
                case 10:
                    background.sprite = dialogueTeeth;
                    Words.text = "Обыграешь меня в карты - скажу.";
                    break;
                case 11:
                    background.sprite = dialogueClosed;
                    Words.text = "";
                    playButton.SetActive(true);
                    break;
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
}
