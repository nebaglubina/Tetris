using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUpdateScoreEvent : IEvent
{
    private int _scoreValue;
    private int _linesValue;

    public int ScoreValue => _scoreValue;
    public int LinesValue => _linesValue;
    
    public IUpdateScoreEvent(int scoreValue, int linesValue)
    {
        _scoreValue = scoreValue;
        _linesValue = linesValue;
    }
}
