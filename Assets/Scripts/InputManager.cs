using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] SequenceDisplay display;
    [SerializeField] PatternDatabase patternDatabase;

    [SerializeField] List<Direction> InputList = new List<Direction>();
    [SerializeField] List<Direction> CurrentSequence = new List<Direction>();

    [SerializeField] AudioClip failSequence;
    [SerializeField] AudioClip enterSequence;
    [SerializeField] AudioClip finishSequence;
    [SerializeField] AudioClip failGame;

    [SerializeField] Animator flicker;

    private AudioSource audioSource;

    private int inputIndex = -1;
    private bool checkInput = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetNewPattern();
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
                audioSource.PlayOneShot(failSequence, 0.5f);
                flicker.SetTrigger("flicker");
            }
            else if (InputList.Count == CurrentSequence.Count) 
            {
                InputList.Clear();
                inputIndex = -1;
                SetNewPattern();
                audioSource.PlayOneShot(finishSequence);
            }
            else
            {
                audioSource.PlayOneShot(enterSequence);
            }

            checkInput = false;
        }
    }

    void SetNewPattern()
    {
        Pattern pattern = patternDatabase.GetRandomPattern();
        display.sequence = CurrentSequence = pattern.Sequence;
        display.startIndex = pattern.startIndex;
        display.Reset();
    }
}
