using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    [SerializeField] Line LineUp;
    [SerializeField] Line LineRight;
    [SerializeField] Line LineDown;
    [SerializeField] Line LineLeft;

    SpriteRenderer sprite;
    [HideInInspector] public SequenceDisplay display;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    public void SetActive(bool active)
    {
        sprite.enabled = active;
    }

    public void Activate(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP:
                if (!LineUp)
                    return;
                LineUp.SetActive(true);
                LineUp.SetNextPointFrom(this);
                break;

            case Direction.RIGHT:
                if (!LineRight)
                    return;
                LineRight.SetActive(true);
                LineRight.SetNextPointFrom(this);
                break;

            case Direction.DOWN:
                if (!LineDown)
                    return;
                LineDown.SetActive(true);
                LineDown.SetNextPointFrom(this);
                break;

            case Direction.LEFT:
                if (!LineLeft)
                    return;
                LineLeft.SetActive(true);
                LineLeft.SetNextPointFrom(this);
                break;
        }
    }
}
