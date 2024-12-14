using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My project/SO_ROAD")]
public class SO_ROAD : ScriptableObject
{
    public Vector3 startPosition = Vector3.zero;
    public float phase1Length = 400f;
    public float phase2Length = 1000f;
    public float offset = -1f; 
}
