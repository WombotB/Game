using UnityEngine;
using System.Collections.Generic;
using System;

public class HandView : MonoBehaviour
{
    public Hand Hand;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private float maxSpacing = 120f;
    [SerializeField] private float maxRotation = 15f;
    [SerializeField] private float arcHeight = 30f;

    private float targetSpacing;
    private float currentSpacing;
    private float targetRotation;
    private float currentRotation;
    private float spacingVelocity;
    private float rotationVelocity;

    public System.Action<CardView> OnCardClicked;

    private List<CardView> _cardViews = new();

    public int Count => Hand.Count;

    void Start()
    {
        Hand = GameManager.Instance.Match.Player.Hand;
        RefreshCards();
    }

    void Update()
    {
        currentSpacing = Mathf.SmoothDamp(currentSpacing, targetSpacing, ref spacingVelocity, 0.25f);
        currentRotation = Mathf.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, 0.25f);
        UpdateCardTransforms();
    }

    public void RefreshCards()
    { 
        foreach (var cv in _cardViews)
            Destroy(cv.gameObject);
        _cardViews.Clear();

        foreach (var card in Hand.Cards)
        {
            var go = Instantiate(cardPrefab, transform);
            var cv = go.GetComponent<CardView>();
            cv.Initialize(card);
            cv.OnCardClicked += HandleCardClicked;
            _cardViews.Add(cv);
        }

        targetSpacing = Mathf.Min(maxSpacing, maxSpacing * 3f / Mathf.Max(Count, 1));
        targetRotation = maxRotation / Mathf.Max(Count, 1) * (Count - 1);
    }

    private void UpdateCardTransforms()
    {
        int count = _cardViews.Count;
        if (count == 0) return;

        float totalWidth = currentSpacing * (count - 1);

        for (int i = 0; i < count; i++)
        {
            float t = count > 1 ? (float)i / (count - 1) - 0.5f : 0f;

            float x = t * totalWidth;
            float y = -arcHeight * (4f * t * t);

            float angle = -currentRotation * t * 2f;

            var rt = _cardViews[i].GetComponent<RectTransform>();
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, new Vector2(x, y), Time.deltaTime * 10f);
            rt.rotation = Quaternion.Lerp(rt.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * 10f);
        }
    }

    private void HandleCardClicked(CardView cv) => OnCardClicked?.Invoke(cv);
}