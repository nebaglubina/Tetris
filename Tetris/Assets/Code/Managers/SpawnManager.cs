using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [Serializable]
    public class Settings
    {
        public float NormalSpeed = 0.5f;
        public float FastSpeed = 0.2f;
    }

    [SerializeField] private GameData _gameData = default;
    [SerializeField] private Transform _shapeParentTransform = default;
    [SerializeField] private Transform _plannedShapeTransform = default;

    private GameObject _plannedShape;
    private GameObject _spawnedShape;
    private ShapeMovement _shapeMovement;
    private Settings _settings;

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

    [Inject]
    private void Construct(ShapeMovement shapeMovement, Settings settings)
    {
        _shapeMovement = shapeMovement;
        _settings = settings;
    }

    private void Spawn(ISpawnEvent e)
    {
        foreach (Transform block in _shapeParentTransform)
        {
            if (block.childCount <= 1)
            {
                Destroy(block.gameObject);
            }
        }

        if (_plannedShape == null)
        {
            var randomShapeIndex = Random.Range(0, _gameData.ShapePrefabs.Length);
            _spawnedShape = Instantiate(_gameData.ShapePrefabs[randomShapeIndex], _shapeParentTransform.position,
                Quaternion.identity, _shapeParentTransform);
        }
        else
        {
            _spawnedShape = _plannedShape;
            _spawnedShape.transform.position = _shapeParentTransform.position;
            _spawnedShape.transform.parent = _shapeParentTransform;
        }
        SpawnPlannedPrefab();
        _shapeMovement.SetTarget(_spawnedShape, _settings.NormalSpeed, _settings.FastSpeed);

    }

    private void SpawnPlannedPrefab()
    {
        var randomShapeIndex = Random.Range(0, _gameData.ShapePrefabs.Length);
        _plannedShape = Instantiate(_gameData.ShapePrefabs[randomShapeIndex], _plannedShapeTransform.position,
            Quaternion.identity, _plannedShapeTransform);
    }

    private void ClearParentTransform(IRestartGameEvent e)
    {
        foreach (Transform shape in _shapeParentTransform)
        {
            Destroy(shape.gameObject);
        }
    }
}