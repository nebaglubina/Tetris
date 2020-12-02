
using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ShapeTypesData _shapeTypesData;
    [SerializeField] private Transform _shapeParentTransform;
    [SerializeField] private Transform _plannedShapeTransform;
    
    private GameObject _plannedShape;
    private GameObject _spawnedShape;
    [Inject] private ShapeMovement _shapeMovement;

    private void OnEnable()
    {
        EventsObserver.AddEventListener<ISpawnEvent>(Spawn);
        EventsObserver.AddEventListener<IRestartGameEvent>(ClearParentTransform);
    }
    private void OnDisable()
    {
        EventsObserver.RemoveEventListener<ISpawnEvent>(Spawn);
        EventsObserver.RemoveEventListener<IRestartGameEvent>(ClearParentTransform);
    }

    private void Spawn(ISpawnEvent e)
    {
        foreach (Transform block in _shapeParentTransform)
        {
            if (block.childCount <= 1)
            {
                Debug.Log($"Destroying {block.gameObject}");
                Destroy(block.gameObject);
            }
        }
        
        if (_plannedShape == null)
        {
            var randomShapeIndex = Random.Range(0, _shapeTypesData.ShapePrefabs.Length);
            _spawnedShape = Instantiate(_shapeTypesData.ShapePrefabs[randomShapeIndex], _shapeParentTransform.position, Quaternion.identity, _shapeParentTransform.transform);
        }
        else
        {
            _spawnedShape = Instantiate(_plannedShape, _shapeParentTransform.position, Quaternion.identity, _shapeParentTransform.transform);
        }
        
        _shapeMovement.SetTarget(_spawnedShape);
        SpawnPlannedPrefab();
    }

    private void SpawnPlannedPrefab()
    {
        if (_plannedShape != null)
        {
            Destroy(_plannedShape.gameObject);
        }
        var randomShapeIndex = Random.Range(0, _shapeTypesData.ShapePrefabs.Length);
        _plannedShape = Instantiate(_shapeTypesData.ShapePrefabs[randomShapeIndex], _plannedShapeTransform.position, Quaternion.identity, _plannedShapeTransform);
    }

    private void ClearParentTransform(IRestartGameEvent e)
    {
        foreach (Transform shape in _shapeParentTransform)
        {
            Destroy(shape.gameObject);
        }
    }
}
