using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _lineScore;
    [SerializeField] private float _lineScoreMultiplier;
    private int _score;
    private int _lines;
    public void AddLineScore(int linesCount)
    {
        Debug.Log($"adding score for {linesCount} lines");
        if (linesCount == 1)
        {
            _score += _lineScore;
        }
        
        else
        {
            _score += (int)(_lineScore * linesCount * _lineScoreMultiplier);
        }
        _lines += linesCount;
        Managers.UIManager.UpdateUIScore(_score, _lines);
    }

    public void ResetScore()
    {
        _score = 0;
        _lines = 0;
    }
}
