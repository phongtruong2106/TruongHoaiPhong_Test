using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My project/SO_SPAWNPREFAB")]
public class SO_SPAWNPREFAB : ScriptableObject
{
    public GameObject roadPrefab;
    public GameObject road;
    public GameObject playerPrefab;
    public GameObject SandPrefab;
    public GameObject SandDecorPrefab;
    public GameObject BeachDecorPrefab;
    public GameObject BeachPrefab;
    public GameObject TsunamiPrefab;
    public GameObject EndPoint;
    public List<GameObject>  DecordPrefab;
    public  float road1Length = 400f; // Chiều dài phase 1
    public  float roadWidth = 180f; // Chiều rộng đường
    public  float road2Length = 1000f; 
}