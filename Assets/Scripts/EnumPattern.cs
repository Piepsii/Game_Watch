using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Pattern
{
    public Pattern(List<Direction> Sequence, int startIndex)
    {
        this.Sequence = Sequence;
        this.startIndex = startIndex;
    }

    public List<Direction> Sequence;
    public int startIndex;
}