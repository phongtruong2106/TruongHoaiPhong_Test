using UnityEngine;

public class GameManager : NewMonoBehaviour
{
    
    [SerializeField] protected UIController uIController;
    public UIController _uiController => uIController;
    [SerializeField] protected TsunamiAT tsunamiAT;
    public TsunamiAT _tsunamiAT => tsunamiAT;
    [SerializeField] protected CheckAnimal checkAnimal;
    public CheckAnimal _checkAnimal => checkAnimal;
    [SerializeField] protected EndPoint endPoint;
    public EndPoint _endPoint => endPoint;

    private bool IsLoad = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
    }
    protected override void Start()
    {
        base.Start();
        this.IsLoad = false;
    }
    private void Update()
    {
        this.LoadCP();
    }
    private void LoadCP()
    {
        if(!this.IsLoad)
        {
            this.LoadTsunamiAT();
            this.LoadCheckAnimal();
            this.LoadEndPoint();    
            this.IsLoad = true;
        }
    }
    private void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }

    private void LoadTsunamiAT()
    {
        if(this.tsunamiAT != null) return;
        this.tsunamiAT = FindAnyObjectByType<TsunamiAT>();
    }
    private void LoadCheckAnimal()
    {
        if(this.checkAnimal != null) return;
        this.checkAnimal = FindAnyObjectByType<CheckAnimal>();
    }
     private void LoadEndPoint()
    {
        if(this.endPoint != null) return;
        this.endPoint = FindAnyObjectByType<EndPoint>();
    }
}