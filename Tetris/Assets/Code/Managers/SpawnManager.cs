
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameData gameData = default;
    [SerializeField] private Transform _shapeParentTransform = default;
    [SerializeField] private Transform _plannedShapeTransform = default;
    
    private GameObject _plannedShape;
    private GameObject _spawnedShape;
    [Inject] private ShapeMovement _shapeMovement = default;

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
                Destroy(block.gameObject);
            }
        }
        
        if (_plannedShape == null)
        {
            var randomShapeIndex = Random.Range(0, gameData.ShapePrefabs.Length);
            _spawnedShape = Instantiate(gameData.ShapePrefabs[randomShapeIndex], _shapeParentTransform.position, Quaternion.identity, _shapeParentTransform.transform);
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
        var randomShapeIndex = Random.Range(0, gameData.ShapePrefabs.Length);
        _plannedShape = Instantiate(gameData.ShapePrefabs[randomShapeIndex], _plannedShapeTransform.position, Quaternion.identity, _plannedShapeTransform);
    }

    private void ClearParentTransform(IRestartGameEvent e)
    {
        foreach (Transform shape in _shapeParentTransform)
        {
            Destroy(shape.gameObject);
        }
    }
}
