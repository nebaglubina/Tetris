
using UnityEngine;
using Zenject;

public class InputManager : IInputManager
{
    private ShapeMovement _shapeMovement;
    

    public InputManager(ShapeMovement shapeMovement)
    {
        _shapeMovement = shapeMovement;
    }
    public void Tick()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _shapeMovement.RotateShape(false);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            _shapeMovement.RotateShape(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _shapeMovement.MoveHorizontal(Vector3.left);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _shapeMovement.MoveHorizontal(Vector3.right);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            _shapeMovement.FastFall(true);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            _shapeMovement.FastFall(false);
        }
    }
}
