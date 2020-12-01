using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShapeTypes", menuName = "Data/ShapeTypes", order = 0)]
public class ShapeTypesData : ScriptableObject
{
    public GameObject[] ShapePrefabs;
}
