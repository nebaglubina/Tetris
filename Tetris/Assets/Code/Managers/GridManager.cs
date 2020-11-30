using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Column
{
    public Transform[] _columnTransform = new Transform[20];
}
public class GridManager : MonoBehaviour
{
    public Column[] _columns = new Column[10];

    public bool IsInsideBoard(Vector2 position)
    {
        return (int) position.x >= 0 && (int) position.x < 10 && (int) position.y >= 0;
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
        StartCoroutine(DeleteRows());
    }
    
    public void UpdateGrid(Transform shape)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
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

    private IEnumerator DeleteRows()
    {
        var fullRowsCount = 0;
        for (int y = 0; y < 20; y++)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y+1);
                y--;
                fullRowsCount++;
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (fullRowsCount > 0)
        {
            Managers.ScoreManager.AddLineScore(fullRowsCount);
        }

        foreach (Transform block in Managers.GameManager.ShapeParent)
        {
            if (block.childCount <= 1)
            {
                Debug.Log($"Destroying {block.gameObject}");
                Destroy(block.gameObject);
            }
        }

        Managers.SpawnManager.Spawn();
    }

    private bool IsRowFull(int transformY)
    {
        for (int i = 0; i < 10; ++i)
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
        for (int i = 0; i < 10; ++i)
        {
            Destroy(_columns[i]._columnTransform[transformY].gameObject);
            _columns[i]._columnTransform[transformY] = null;
        }
    }

    private void DecreaseRowsAbove(int rowsCount)
    {
        for (int i = rowsCount; i < 20; ++i)
        {
            DecreaseRow(i);
        }
    }

    private void DecreaseRow(int transformY)
    {
        for (int i = 0; i < 10; ++i)
        {
            if (_columns[i]._columnTransform[transformY] != null)
            {
                _columns[i]._columnTransform[transformY - 1] = _columns[i]._columnTransform[transformY];
                _columns[i]._columnTransform[transformY] = null;
                _columns[i]._columnTransform[transformY - 1].position += Vector3.down;
            }
        }
    }
    
    public void ClearBoard()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (_columns[j]._columnTransform[i] != null)
                {
                    Destroy(_columns[j]._columnTransform[i].gameObject);
                    _columns[j]._columnTransform[i] = null;
                }
            }
        }

        foreach (Transform shape in Managers.GameManager.ShapeParent)
        {
            Destroy(shape.gameObject);
        }
    }
}
