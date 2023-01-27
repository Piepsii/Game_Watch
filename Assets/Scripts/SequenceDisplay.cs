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

    [SerializeField] List<Direction> sequence;
    int sequenceIndex = 0;

    private void Start()
    {
        foreach (Origin or in gameObject.GetComponentsInChildren<Origin>())
            originList.Add(or);

        foreach (Line line in gameObject.GetComponentsInChildren<Line>())
            lineList.Add(line);

        start = originList[0];
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
}
