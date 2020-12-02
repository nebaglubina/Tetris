using UnityEngine;

public class ScoreManager
{
    private int _lineScore = 100;
    private float _lineScoreMultiplier = 1.2f;
    private int _score;
    private int _lines;
    private UIManager _uiManager;

    public ScoreManager(UIManager uiManager)
    {
        _uiManager = uiManager;
    }

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
        _uiManager.UpdateUIScore(_score, _lines);
    }

    public void ResetScore()
    {
        _score = 0;
        _lines = 0;
        _uiManager.UpdateUIScore(_score, _lines);
    }
}
