﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShapeType
{
    I,
    O,
    T,
    S,
    Z,
    J,
    L
}
public class Shape : MonoBehaviour
{
    private ShapeType _shapeType;
    private ShapeMovement _shapeMovement;

    public ShapeMovement ShapeMovement
    {
        get => _shapeMovement;
        set => _shapeMovement = value;
    }

    public Shape(ShapeMovement shapeMovement)
    {
        _shapeMovement = shapeMovement;
    }

    private void Awake()
    {
        _shapeMovement = GetComponent<ShapeMovement>();
    }


    private void Start()
    {
        if (!Managers.GridManager.IsValidGridPosition(transform))
        {
            Managers.GameManager.SetState(typeof(EndgameState));
            Destroy(gameObject);
        }
    }
}