using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My project/SO_Cabinet")]
public class SO_Cabinet : ScriptableObject
{
    public List<GameObject> cabinetPrefabs;
    public List<Vector3> spawnPositions = new List<Vector3>
    {
        new Vector3(30f, 1,70),
        new Vector3(-20.7f, 1, 58.3f),
        new Vector3(24.6f, 1,200f),
        new Vector3(-19.9f, 1,100),
        new Vector3(-10f, 1,300),
        new Vector3(-18, 1,350)
    };
}