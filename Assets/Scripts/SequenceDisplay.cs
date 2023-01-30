using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class SequenceDisplay : MonoBehaviour
{
    Origin start;
    Origin currentPoint;

    List<Origin> originList = new List<Origin>();
    List<Line> lineList = new List<Line>();

    public List<Direction> sequence = new List<Direction>();
    [Range(0, 8)] public int startIndex = 1;
    int sequenceIndex = 0;
    bool delayActive = false;

    [HideInInspector] public List<SpriteRenderer> InfillRenderers = new List<SpriteRenderer>();
    private int infillIndex = 0;

    public void Start()
    {
        foreach (Origin or in gameObject.GetComponentsInChildren<Origin>())
            originList.Add(or);

        foreach (Line line in gameObject.GetComponentsInChildren<Line>())
            lineList.Add(line);
    }

    public void DoReset()
    {
        start = originList[startIndex];
        currentPoint = start;
        sequenceIndex = 0;
        ResetInfill();
        InfillRenderers.Clear();
        infillIndex = 0;

        foreach (Origin origin in originList)
        {
            origin.display = this;
            origin.SetActive(false);
        }
        start.SetActive(true);

        foreach (Line line in lineList)
        {

            line.display = this;
            line.SetActive(false);
        }

        NextLine();
    }

    public void UpdateCurrentPoint(Origin point)
    {

        sequenceIndex++;

        if (sequenceIndex >= sequence.Count)
            return;


        currentPoint = point;
        NextLine();
    }

    private void NextLine()
    {
        if (!delayActive)
            StartCoroutine(DelayLine());
    }

    public List<Direction> GetSequence()
    {
        return sequence;
    }

    public int GetStartIndex()
    {
        return startIndex;
    }


    IEnumerator DelayLine()
    {
        delayActive = true;
        yield return new WaitForSeconds(0.07f);

        delayActive = false;
        currentPoint.Activate(sequence[sequenceIndex]);
    }

    public void ResetInfill()
    {
        foreach (SpriteRenderer sprite in InfillRenderers)
            sprite.enabled = false;
    }

    public void EnableInfill(int current)
    {
        for(int i = 0; i < current; i++)
        {
            InfillRenderers[i].enabled = true;
        }
    }
}
