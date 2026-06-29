using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Cutscene4 : MonoBehaviour
{
    [SerializeField] private TMP_Text Words;
    [SerializeField] private GameObject SFXM;
    [SerializeField] private GameObject pause;
    [SerializeField] private Image background;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;
    private int i = 1;
    void Start()
    {

    }

    void Update()
    {
        if (!pause.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            i++;
            switch (i)
            {
                //case 1:
                //    background.sprite = sprite2;
                //    Words.text = "Почему у меня на лбу цветок?";
                //    break;
                case 2:
                    background.sprite = sprite3;
                    Words.text = "А ты не знаешь?";
                    break;
                case 3:
                    background.sprite = sprite2;
                    Words.text = "Нет, не знаю.";
                    break;
                case 4:
                    background.sprite = sprite3;
                    Words.text = "Нет, знаешь.";
                    break;
                case 5:
                    background.sprite = sprite1;
                    Words.text = "Мы - один человек?...";
                    break;
                case 6:
                    background.sprite = sprite4;
                    Words.text = "Правильно.";
                    break;
                case 7:
                    SceneManager.LoadScene("Boom");
                    break;
            }
        }
    }
}
