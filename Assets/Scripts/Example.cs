using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Example : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip NewClip;
    [SerializeField] private GameObject DialogueW;
    [SerializeField] private TMP_Text Name;
    [SerializeField] private TMP_Text Words;
    [SerializeField] private AudioClip doorSound;
    [SerializeField] private GameObject SFXM;
    [SerializeField] private GameObject background;
    private bool key = true;
    private int i = 1;

    void Start()
    {
        PlayerPrefs.SetInt("End", 0);
    }

    void Update()
    {
        if (key) { 
            if ((int)videoPlayer.frame == (int)videoPlayer.frameCount - 1)
            {
                videoPlayer.clip = NewClip;
                key = false;
                DialogueW.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                i++;
                switch (i)
                {
                        //case 1:
                        //    Name.text = "...";
                        //    Words.text = "«ДОБРОЕ УТРО!» - кричит в голове.";
                        //    break;
                    case 2:
                        Name.text = "...";
                        Words.text = "С минуты на минуту сюда зайдет медсестра и скажет мне это. ";
                        break;
                    case 3:
                        Name.text = "...";
                        Words.text = "Я опять проснулась от жара. ";
                        break;
                    case 4:
                        Name.text = "...";
                        Words.text = "С момента моей госпитализации прошел месяц, и с каждым днем я все больше убеждаюсь, что лечить меня тут никто не собирается. ";
                        break;
                    case 5:
                        Name.text = "...";
                        Words.text = "Они только обследуют и исследуют меня, и, когда мне становится совсем плохо, дают что-то, что поддерживает мое состояние на «терпимо-ужасном».";
                        break;
                    case 6:
                        Name.text = "...";
                        Words.text = "Я скучаю по маме и папе.";
                        break;
                    case 7:
                        Name.text = "Медсестра";
                        Words.text = "Доброе утро!";
                        SFXM.GetComponent<AudioSource>().clip = doorSound;
                        SFXM.GetComponent<AudioSource>().Play();
                        background.SetActive(false);
                        break;
                    case 8:
                        Name.text = "...";
                        Words.text = "Мне сделали укол и стало совсем плохо. Я попыталась сконцентрироваться, в прошлые разы это помогало.";
                        break;
                    case 9:
                        SceneManager.LoadScene("Level1");
                        break;
                }
            }
        }
    }
}
