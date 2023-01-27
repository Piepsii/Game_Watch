using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] SequenceDisplay display;

    [SerializeField] List<Direction> InputList = new List<Direction>();
    [SerializeField] List<Direction> CurrentSequence = new List<Direction>();

    private int inputIndex = -1;
    private bool checkInput = false;

    private void Start()
    {
        display.sequence = CurrentSequence;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            InputList.Add(Direction.UP);
            checkInput = true;
        }

        else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            InputList.Add(Direction.RIGHT);
            checkInput = true;
        }

        else if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            InputList.Add(Direction.DOWN);
            checkInput = true;
        }

        else if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            InputList.Add(Direction.LEFT);
            checkInput = true;
        }

        if (checkInput)
        {
            inputIndex++;

            if (InputList[inputIndex] != CurrentSequence[inputIndex])
            {
                InputList.Clear();
                inputIndex = -1;
            }

            checkInput = false;
        }
    }
}
