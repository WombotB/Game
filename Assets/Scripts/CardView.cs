using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    public Image cardImage;
    public Text cardNameText;
    public Text healthText;
    public Text damageText;

    public CardInstance Card { get; private set; }

    // Событие клика (подписывается GameManager)
    public System.Action<CardView> OnCardClicked;

    // Инициализация карты из модели
    public void Initialize(CardInstance card)
    {
        Card = card;

        if (cardNameText != null)
            cardNameText.text = Card.Data.Name;

        if (healthText != null)
            healthText.text = Card.CurrentHealth.ToString();

        if (damageText != null)
            damageText.text = Card.CurrentDamage.ToString();

        if (cardImage != null && Card.Data.Icon != null)
            cardImage.sprite = Card.Data.Icon;
    }

    public void UpdateView()
    {
        if (Card == null) return;

        if (healthText != null) { healthText.text = Card.CurrentHealth.ToString(); }

        if (damageText != null) { damageText.text = Card.CurrentDamage.ToString(); }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnCardClicked?.Invoke(this);
    }
}