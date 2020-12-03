
using System;

public class ScoreManager
{
    [Serializable]
    public class Settings
    {
        public int _lineScore = 100;
        public float _lineScoreMultiplier = 1.2f;
    }
    
    private int _score;
    private int _lines;
    private UIManager _uiManager;
    private Settings _settings;

    public ScoreManager(UIManager uiManager, Settings settings)
    {
        _uiManager = uiManager;
        _settings = settings;
    }

    public void AddLineScore(int linesCount)
    {
        if (linesCount == 1)
        {
            _score += _settings._lineScore;
        }
        
        else
        {
            _score += (int)(_settings._lineScore * linesCount * _settings._lineScoreMultiplier);
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
