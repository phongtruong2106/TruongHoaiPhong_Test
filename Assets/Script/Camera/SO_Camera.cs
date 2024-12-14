using UnityEngine;

[CreateAssetMenu(menuName = "My project/SO_Camera")]
public class SO_Camera : ScriptableObject
{

    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float xRosOffset;
    public float yRosOffset;
    
    public float followSpeed = 1;
    public float defaultxOffset;
    public float defaultyOffset;
    public float defaulFollowSpeed = 1;
}