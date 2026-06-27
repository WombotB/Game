using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    [SerializeField] private GameObject galleryPanel;
    public void Show()
    {
        galleryPanel.SetActive(true);
        galleryPanel.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
    }
}
