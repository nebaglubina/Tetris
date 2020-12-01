
using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ShapeTypesData _shapeTypesData;

    private GameObject _plannedShape;
    private GameObject _spawnedShape;
    private IInputManager _inputManager;
    private IGameManager _gameManager;
    private ShapeMovement _shapeMovement;

    [Inject]
    private void Construct(IInputManager inputManager, IGameManager gameManager, ShapeMovement shapeMovement)
    {
        _inputManager = inputManager;
        _gameManager = gameManager;
        _shapeMovement = shapeMovement;
    }
    public void Spawn()
    {
        if (_plannedShape == null)
        {
            var randomShapeIndex = Random.Range(0, _shapeTypesData.ShapePrefabs.Length);
            _spawnedShape = Instantiate(_shapeTypesData.ShapePrefabs[randomShapeIndex]);
        }
        else
        {
            _spawnedShape = _plannedShape;
        }
        _gameManager.CurrentShape = _spawnedShape.GetComponent<Shape>();
        _spawnedShape.transform.parent = _gameManager.ShapeParent;
        _spawnedShape.transform.position = _gameManager.ShapeParent.position;
        var shape = _spawnedShape.GetComponent<Shape>();
        shape.enabled = true;
        _inputManager.IsActive = true;
        _shapeMovement.SetTarget(shape);
        SpawnPlannedPrefab();
    }

    private void SpawnPlannedPrefab()
    {
        foreach (Transform child in _gameManager.PlannedShape)
        {
            Destroy(child.gameObject);
        }
        var randomShapeIndex = Random.Range(0, _shapeTypesData.ShapePrefabs.Length);
        _plannedShape = Instantiate(_shapeTypesData.ShapePrefabs[randomShapeIndex]);
        _plannedShape.transform.parent = _gameManager.PlannedShape;
        _plannedShape.transform.position = _gameManager.PlannedShape.position;
    }
}
