using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _shapePrefabs;

    private GameObject _plannedShape;
    private GameObject _spawnedShape;
    public void Spawn()
    {
        if (_plannedShape == null)
        {
            var randomShapeIndex = Random.Range(0, _shapePrefabs.Length);
            _spawnedShape = Instantiate(_shapePrefabs[randomShapeIndex]);
        }
        else
        {
            _spawnedShape = _plannedShape;
        }
        Managers.GameManager.CurrentShape = _spawnedShape.GetComponent<Shape>();
        _spawnedShape.transform.parent = Managers.GameManager.ShapeParent;
        _spawnedShape.transform.position = Managers.GameManager.ShapeParent.position;
        _spawnedShape.GetComponent<Shape>().enabled = true;
        Managers.InputManager.IsActive = true;
        SpawnPlannedPrefab();
    }

    public void SpawnPlannedPrefab()
    {
        foreach (Transform child in Managers.GameManager.PlannedShape)
        {
            Destroy(child.gameObject);
        }
        var randomShapeIndex = Random.Range(0, _shapePrefabs.Length);
        _plannedShape = Instantiate(_shapePrefabs[randomShapeIndex]);
        _plannedShape.transform.parent = Managers.GameManager.PlannedShape;
        _plannedShape.transform.position = Managers.GameManager.PlannedShape.position;

    }
}
