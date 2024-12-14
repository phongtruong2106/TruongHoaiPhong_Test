using UnityEngine;

public class TsunamiAT : NewMonoBehaviour
{
    public bool isPlayer;
    public bool isEnd;
    protected override void Start()
    {
        base.Start();
        this.isPlayer = false;
        this.isEnd = false;
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!isPlayer)
            {
                this.isEnd = true;
                this.isPlayer = true;    
            }
        }
    }
}