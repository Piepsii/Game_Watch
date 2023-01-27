using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] Origin PointA;
    [SerializeField] Origin PointB;
    [HideInInspector] public SequenceDisplay display;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    public void SetActive(bool active)
    {
        sprite.enabled = active;
    }

    public void SetNextPointFrom(Origin start)
    {
        if (start == PointA)
            display.UpdateCurrentPoint(PointB);
        else if (start == PointB)
            display.UpdateCurrentPoint(PointA);
        else
            Debug.LogError("Shit broke");
    }
}
