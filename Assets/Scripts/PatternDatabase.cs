using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatternDatabase", menuName = "Custom/PatternDatabase")]
public class PatternDatabase : ScriptableObject
{
    public List<Pattern> patterns = new List<Pattern>();
    public Pattern GetRandomPattern()
    {
        int randomIndex = Random.Range(0, patterns.Count);
        return patterns[randomIndex];
    }
}