using UnityEngine;

[CreateAssetMenu(menuName = "My project/SO_CHECKANIMAL")]
public class SO_CHECKANIMAL : ScriptableObject
{
    public Vector3 coneCenter = Vector3.zero;
    public float coneRadius = 10f; 
    public float coneHeight = 20f; 
    public int numSegments = 36; 
}