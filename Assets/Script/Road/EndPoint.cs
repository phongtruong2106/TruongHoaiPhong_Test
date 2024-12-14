using UnityEngine;

public class EndPoint : NewMonoBehaviour
{
    public bool isPlayer;
    public bool isEnd;
    public bool isLEnd;
    protected override void Start()
    {
        base.Start();
        this.isPlayer = false;
        this.isLEnd = false;
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!isPlayer)
            {
                if(!isLEnd)
                {
                    this.isEnd = true;
                    this.isLEnd = true;
                }
                
                this.isPlayer = true;
            }
        }
    }
}