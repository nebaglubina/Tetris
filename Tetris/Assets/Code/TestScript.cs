using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [ContextMenu("check v2 position")]
    public void Checkv2position()
    {
        foreach (Transform child in this.transform)
        {
            Vector2 pos = child.position;
            Debug.Log($"Vector = {pos}");
        }
    }

}
