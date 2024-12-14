using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My project/SO_MEOW")]
public class SO_MEOW : ScriptableObject
{
    public List<GameObject> catPrefabs;
    public List<Vector3> spawnPositions = new List<Vector3>
    {
        new Vector3(-30.1f, 1,90 ),
        new Vector3(30.1f, 1,50 ),
        new Vector3(-21.5f, 1,240),
        new Vector3(15.2f, 1,160),
        new Vector3(20f, 1,290),
        new Vector3(60, 1,370)
    };
}