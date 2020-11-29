using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool isActive;

    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    private void Update()
    {
        if (!isActive || Managers.GameManager.CurrentShape == null) return;
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Managers.GameManager.CurrentShape.ShapeMovement.RotateShape(false);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Managers.GameManager.CurrentShape.ShapeMovement.RotateShape(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Managers.GameManager.CurrentShape.ShapeMovement.MoveHorizontal(Vector3.left);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Managers.GameManager.CurrentShape.ShapeMovement.MoveHorizontal(Vector3.right);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Managers.GameManager.CurrentShape.ShapeMovement.FastFall(true);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            Managers.GameManager.CurrentShape.ShapeMovement.FastFall(false);
        }
    }
}
