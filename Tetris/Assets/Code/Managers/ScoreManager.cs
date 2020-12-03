
using System;

public class ScoreManager :IScoreManager
{
    [Serializable]
    public class Settings
    {
        public int _lineScore = 100;
        public float _lineScoreMultiplier = 1.2f;
    }
    
    private int _score;
    private int _lines;
    private Settings _settings;

    public int Score => _score;

    public ScoreManager(Settings settings)
    {
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
        EventsObserver.Publish(new IUpdateScoreEvent(_score, _lines));
    }

    public void ResetScore()
    {
        _score = 0;
        _lines = 0;
        EventsObserver.Publish(new IUpdateScoreEvent(_score, _lines));
    }
}
