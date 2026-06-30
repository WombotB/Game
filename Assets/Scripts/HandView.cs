using UnityEngine;
using System.Collections.Generic;
using System;

public class HandView : MonoBehaviour
{
    public Hand Hand = GameManager.Instance.Match.Player.Hand;

    private float targetSpacing = 0f;
    private float currentSpacing = 0f;
    private float cardTargetRotation = 0f;
    private float cardCurrentRotation = 45f;
    private static float cardMaxRotation = 45f;
    private float velocity = 0f;

    public List<Vector2> CardPositions = new List<Vector2>();
    public List<Quaternion> CardRotations = new List<Quaternion>();

    public int Count => Hand.Count;

    /*void Start()
    {
        
    }*/

    void Update()
    {
        currentSpacing = Mathf.SmoothDamp(currentSpacing, targetSpacing, ref velocity, 0.5f);
    }

    void UpdateView()
    {
        targetSpacing = 1f / Mathf.Max(Count, 1);
        cardTargetRotation = cardMaxRotation / Mathf.Max(Count, 1);
    }
}
