using UnityEngine;

[CreateAssetMenu(menuName = "My project/SO_TSUNAMI")]
public class SO_TSUNAMI : ScriptableObject
{
    public float phase1Speed = 10f;
    public float phase2Speed = 40f; 
    public float phase1Length = 400f;
    public float phase2Length = 1000f; 
    public float startDelayPhase1 = 15f; 
    public float startDelayPhase2 = 25f;

    public float startTime;
    public bool isPhase1Active = false;
    public bool isPhase2Active = false;
}