using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatternFactory : MonoBehaviour
{
    [SerializeField] PatternDatabase patternDatabase;
    private List<Pattern> patterns = new List<Pattern>();
    private List<SequenceDisplay> displays = new List<SequenceDisplay>();

    void Start()
    {
        displays = new List<SequenceDisplay>(GetComponentsInChildren<SequenceDisplay>());
        foreach(SequenceDisplay display in displays)
        {
            var newPattern = new Pattern(
                display.GetSequence(),
                display.GetStartIndex());
            patterns.Add(newPattern);
        }
        patternDatabase.patterns = patterns;
    }

}
