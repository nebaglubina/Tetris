﻿using System;
using UnityEngine;
using Zenject;

public class GridManager: IInitializable, IDisposable
{
    private int transformsYCount = 20;
    private int columnsCount = 10;
    private Column[] _columns;

    
    private ScoreManager _scoreManager;

    public GridManager(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }
    
    public void Initialize()
    {
        _columns = new Column[columnsCount];
        EventsObserver.AddEventListener<IRestartGameEvent>(RestartListener);
        for (int i = 0; i < columnsCount; i++)
        {
            _columns[i] = new Column(new Transform[transformsYCount]);
        }
    }

    private void RestartListener(IRestartGameEvent e)
    {
        Debug.Log("Resetting score");
        ClearBoard();
        _scoreManager.ResetScore();
    }


    public bool IsInsideBoard(Vector2 position)
    {
        return (int) position.x >= 0 && (int) position.x < columnsCount && (int) position.y >= 0;
    }
    public bool IsValidGridPosition(Transform shape)
    {
        foreach (Transform child in shape)
        {
            if (child.gameObject.tag.Equals("Block"))
            {
                var childVector = new Vector2(Mathf.Round(child.position.x), Mathf.Round(child.position.y));
                if (!IsInsideBoard(childVector))
                {
                    return false;
                }
                if (_columns[(int) childVector.x]._columnTransform[(int) childVector.y] != null &&
                    _columns[(int) childVector.x]._columnTransform[(int) childVector.y].parent != shape)
                {
                    return false;
                }
            }
        }

        return true;
    }


    public void PlaceShape()
    {
        DeleteRows();
    }
    
    public void UpdateGrid(Transform shape)
    {
        for (int i = 0; i < transformsYCount; i++)
        {
            for (int j = 0; j < columnsCount; j++)
            {
                if (_columns[j]._columnTransform[i] != null)
                {
                    if (_columns[j]._columnTransform[i].parent == shape)
                    {
                        _columns[j]._columnTransform[i] = null;
                    }
                }
            }
        }
        foreach (Transform child in shape)
        {
            if (child.gameObject.tag.Equals("Block"))
            {
                var childVector = new Vector2(Mathf.Round(child.position.x), Mathf.Round(child.position.y));
                _columns[(int) childVector.x]._columnTransform[(int) childVector.y] = child;
            }
        }
    }

    private void DeleteRows()
    {
        var fullRowsCount = 0;
        for (int y = 0; y < transformsYCount; y++)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y+1);
                y--;
                fullRowsCount++;
            }
        }
        if (fullRowsCount > 0)
        {
            _scoreManager.AddLineScore(fullRowsCount);
        }

        EventsObserver.Publish(new ISpawnEvent());
    }

    private bool IsRowFull(int transformY)
    {
        for (int i = 0; i < columnsCount; ++i)
        {
            if (_columns[i]._columnTransform[transformY] == null)
            {
                return false;
            }
        }
        Debug.Log("Row is full");
        return true;
    }

    private void DeleteRow(int transformY)
    {
        Debug.Log("deleting row");
        for (int i = 0; i < columnsCount; ++i)
        {
            GameObject.Destroy(_columns[i]._columnTransform[transformY].gameObject);
            _columns[i]._columnTransform[transformY] = null;
        }
    }

    private void DecreaseRowsAbove(int rowsCount)
    {
        for (int i = rowsCount; i < transformsYCount; ++i)
        {
            DecreaseRow(i);
        }
    }

    private void DecreaseRow(int transformY)
    {
        for (int i = 0; i < columnsCount; ++i)
        {
            if (_columns[i]._columnTransform[transformY] != null)
            {
                _columns[i]._columnTransform[transformY - 1] = _columns[i]._columnTransform[transformY];
                _columns[i]._columnTransform[transformY] = null;
                _columns[i]._columnTransform[transformY - 1].position += Vector3.down;
            }
        }
    }

    public void Dispose()
    {
        EventsObserver.AddEventListener<IRestartGameEvent>(RestartListener);
    }
    public void ClearBoard()
    {
        for (int i = 0; i < transformsYCount; i++)
        {
            for (int j = 0; j < columnsCount; j++)
            {
                if (_columns[j]._columnTransform[i] != null)
                {
                    GameObject.Destroy(_columns[j]._columnTransform[i].gameObject);
                    _columns[j]._columnTransform[i] = null;
                }
            }
        }
    }
}
