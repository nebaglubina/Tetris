using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMovement : MonoBehaviour
{
    private Transform _rotationPivot;
    private float _normalTransitionInterval = 0.5f;
    private float _fastTransitionInterval = 0.2f;
    private float currentTransitionInterval = 0.5f;
    private float lastFallTime;

    private void Awake()
    {
        currentTransitionInterval = _normalTransitionInterval;
        _rotationPivot = transform.Find("Pivot");
    }

    public void ShapeUpdate()
    {
        FreeFall();
    }

    public void FastFall(bool isEnabled)
    {
        currentTransitionInterval = isEnabled ? _fastTransitionInterval : _normalTransitionInterval;
    }

    public void MoveHorizontal(Vector3 direction)
    {
        transform.position += direction;
        if (Managers.GridManager.IsValidGridPosition(transform))
        {
            Managers.GridManager.UpdateGrid(transform);
        }
        else
        {
            transform.position -= direction;
        }
    }

    public void RotateShape(bool isClockwise)
    {
        float rotationDegree = isClockwise ? 90.0f : -90.0f;
        transform.RotateAround(_rotationPivot.position, Vector3.forward, rotationDegree);
        if (Managers.GridManager.IsValidGridPosition(transform))
        {
            Managers.GridManager.UpdateGrid(transform);
        }
        else
        {
            transform.RotateAround(_rotationPivot.position, Vector3.forward, -rotationDegree);
        }
    }

    private void FreeFall()
    {
        if (!(Time.time - lastFallTime >= currentTransitionInterval)) return;
        
        transform.position += Vector3.down;
            
        if (Managers.GridManager.IsValidGridPosition(transform))
        {
            Managers.GridManager.UpdateGrid(transform);
        }
        else
        {
            transform.position += Vector3.up;

            foreach (Transform child in this.transform)
            {
                if (child.tag.Equals("Block"))
                {
                    Vector2 vec = child.position;
                    Debug.Log(vec);
                }
            }
            GetComponent<ShapeMovement>().enabled = false;
            GetComponent<Shape>().enabled = false;
            Managers.GameManager.CurrentShape = null;
            Managers.GridManager.PlaceShape();
        }

        lastFallTime = Time.time;
    }
}
