using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreManager
{
    void AddLineScore(int linesCount);
    void ResetScore();
    int Score { get; }
}
