using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SequenceDisplay : MonoBehaviour
{
    Origin start;
    Origin currentPoint;

    List<Origin> originList = new List<Origin>();
    List<Line> lineList = new List<Line>();

    public List<Direction> sequence;
    [Range(0, 8)] [SerializeField] int startIndex = 1;
    int sequenceIndex = 0;

    private void Start()
    {
        foreach (Origin or in gameObject.GetComponentsInChildren<Origin>())
            originList.Add(or);

        foreach (Line line in gameObject.GetComponentsInChildren<Line>())
            lineList.Add(line);

        start = originList[startIndex];
        start.SetActive(true);
        currentPoint = start;

        foreach (Origin origin in originList)
            origin.display = this;

        foreach (Line line in lineList)
            line.display = this;

        NextLine();
    }

    public void UpdateCurrentPoint(Origin point)
    {
        sequenceIndex++;
        currentPoint = point;
        NextLine();
    }

    private void NextLine()
    {
        Debug.Log(sequenceIndex);

        if (sequenceIndex >= sequence.Count)
            return;

        currentPoint.Activate(sequence[sequenceIndex]);
    }

    public List<Direction> GetSequence()
    {
        return sequence;
    }

    public int GetStartIndex()
    {
        return startIndex;
    }
}
