using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Pattern
{
    public Pattern(List<Direction> Sequences, int startIndex)
    {
        this.Sequences = Sequences;
        this.startIndex = startIndex;
    }

    public List<Direction> Sequences;
    public int startIndex;
}