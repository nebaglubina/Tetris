using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Extension
{
    public static Vector2 roundVector2(Vector2 vector)
    {
        // Debug.Log($"initial vec2 = {vector}");
        // Debug.Log($"correct vec2 = {new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y))}");
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }
}
