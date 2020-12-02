using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData", order = 0)]
public class GameData : ScriptableObject
{
    [SerializeField] private GameObject[] _shapePrefabs = default;
    [SerializeField] private AudioClip[] _clips = default;
    
    public GameObject[] ShapePrefabs => _shapePrefabs;
    public AudioClip[] Clips => _clips;
    
}
