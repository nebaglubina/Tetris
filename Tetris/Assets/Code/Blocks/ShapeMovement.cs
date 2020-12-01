using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMovement
{
    private Transform _rotationPivot;
    private float _normalTransitionInterval = 0.5f;
    private float _fastTransitionInterval = 0.2f;
    private float currentTransitionInterval = 0.5f;
    private float lastFallTime;
    private Shape _shape;
    private GridManager _gridManager;
    
    public ShapeMovement (GridManager gridManager)
    {
        _gridManager = gridManager;
    }

    public void SetTarget(Shape shape)
    {
        _shape = shape;
        currentTransitionInterval = _normalTransitionInterval;
        _rotationPivot = shape.transform.Find("Pivot");
    }

    public void ShapeUpdate()
    {
        if (_shape == null)
        {
            return;
        }
            FreeFall();
    }

    public void FastFall(bool isEnabled)
    {
        currentTransitionInterval = isEnabled ? _fastTransitionInterval : _normalTransitionInterval;
    }

    public void MoveHorizontal(Vector3 direction)
    {
        if (_shape == null)
        {
            return;
        }
        _shape.transform.position += direction;
        if (_gridManager.IsValidGridPosition(_shape.transform))
        {
            _gridManager.UpdateGrid(_shape.transform);
        }
        else
        {
            _shape.transform.position -= direction;
        }
    }

    public void RotateShape(bool isClockwise)
    {
        if (_shape == null)
        {
            return;
        }
        float rotationDegree = isClockwise ? 90.0f : -90.0f;
        _shape.transform.RotateAround(_rotationPivot.position, Vector3.forward, rotationDegree);
        if (_gridManager.IsValidGridPosition(_shape.transform))
        {
            _gridManager.UpdateGrid(_shape.transform);
        }
        else
        {
            _shape.transform.RotateAround(_rotationPivot.position, Vector3.forward, -rotationDegree);
        }
    }

    private void FreeFall()
    {
        if (!(Time.time - lastFallTime >= currentTransitionInterval)) return;
        
        _shape.transform.position += Vector3.down;
            
        if (_gridManager.IsValidGridPosition(_shape.transform))
        {
            _gridManager.UpdateGrid(_shape.transform);
        }
        else
        {
            _shape.transform.position += Vector3.up;

            foreach (Transform child in _shape.transform)
            {
                if (child.tag.Equals("Block"))
                {
                    Vector2 vec = child.position;
                }
            }
            
            _shape.GetComponent<Shape>().enabled = false;
            _gridManager.PlaceShape();
        }

        lastFallTime = Time.time;
    }
}
