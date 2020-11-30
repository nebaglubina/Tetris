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
    public Column[] _columns = new Column[10]; //TODO naming and lines/columns count options

    public bool IsInsideBorder(Vector2 position)
    {
        return (int) position.x >= 0 && (int) position.x < 10 && (int) position.y >= 0;
    }

    public void PlaceShape()
    {
        StartCoroutine(DeleteRows());
    }

    private IEnumerator DeleteRows()
    {
        for (int y = 0; y < 20; ++y)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y+1);
                --y;
                yield return new WaitForSeconds(0.5f);
            }
        }

        foreach (Transform t in Managers.GameManager.BlockHolder)
        {
            if (t.childCount <= 1)
            {
                Debug.Log($"Destroying {t.gameObject}");
                Destroy(t.gameObject);
            }
        }

        Managers.SpawnManager.Spawn();
    }

    private bool IsRowFull(int rowNumber)
    {
        for (int i = 0; i < 10; ++i)
        {
            if (_columns[i]._columnTransform[rowNumber] == null)
            {
                return false;
            }
        }
        Debug.Log("Row is full");
        return true;
    }

    private void DeleteRow(int rowNumber)
    {
        Debug.Log("deleting row");
        for (int i = 0; i < 10; ++i)
        {
            Destroy(_columns[i]._columnTransform[rowNumber].gameObject);
            _columns[i]._columnTransform[rowNumber] = null;
        }
    }

    private void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < 20; ++i)
        {
            DecreaseRow(i);
        }
    }

    private void DecreaseRow(int y)
    {
        for (int i = 0; i < 10; ++i)
        {
            if (_columns[i]._columnTransform[y] != null)
            {
                _columns[i]._columnTransform[y - 1] = _columns[i]._columnTransform[y];
                _columns[i]._columnTransform[y] = null;
                _columns[i]._columnTransform[y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public bool IsValidGridPosition(Transform obj)
    {
        foreach (Transform child in obj)
        {
            if (child.gameObject.tag.Equals("Block"))
            {
                Vector2 childVector = Vector2Extension.roundVector2(child.position);
                if (!IsInsideBorder(childVector))
                {
                    Debug.Log("Is not inside border");
                    return false;
                }

                if (_columns[(int) childVector.x]._columnTransform[(int) childVector.y] != null &&
                    _columns[(int) childVector.x]._columnTransform[(int) childVector.y].parent != obj)
                {
                    Debug.Log("Some other reason");
                    return false;
                }
            }
        }

        return true;
    }

    public void UpdateGrid(Transform obj) //TODO pay attention how
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (_columns[j]._columnTransform[i] != null)
                {
                    if (_columns[j]._columnTransform[i].parent == obj)
                    {
                        _columns[j]._columnTransform[i] = null;
                    }
                }
            }
        }

        foreach (Transform child in obj)
        {
            if (child.gameObject.tag.Equals("Block"))
            {
                Vector2 childVector = Vector2Extension.roundVector2(child.position);
                _columns[(int) childVector.x]._columnTransform[(int) childVector.y] = child;
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

        foreach (Transform t in Managers.GameManager.BlockHolder)
        {
            Destroy(t.gameObject);
        }
    }
}
