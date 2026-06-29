using UnityEngine;

public class BoardView : MonoBehaviour
{
    private Dictionary<CardInstance, CardView> cardViews;

    private CardView selectedCard;

    public void SelectCard(CardView card)
    {
        if (selectedCard != null)
            selectedCard.Deselect();

        selectedCard = card;
        selectedCard.Select();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
