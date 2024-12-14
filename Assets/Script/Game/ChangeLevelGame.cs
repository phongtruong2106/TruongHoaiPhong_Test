using UnityEngine;

public class ChangeLevelGame : NewMonoBehaviour
{
    [SerializeField] protected EndPoint endPoint;  
    [SerializeField] private SO_TSUNAMI sO_TSUNAMI; 
    [SerializeField] private int currentLevel = 1; 
    [SerializeField] private int maxLevel = 10;   
    public bool isLoadC;

    private float initialPhase1Speed;
    private float initialPhase2Speed;
    private float maxPhase1Speed = 50f; 
    private float maxPhase2Speed = 100f; 

    protected override void Start()
    {
        base.Start();
        this.isLoadC = false;
        initialPhase1Speed = sO_TSUNAMI.phase1Speed;
        initialPhase2Speed = sO_TSUNAMI.phase2Speed;
        LoadData();
        Debug.Log($"Level hiện tại: {currentLevel}, Phase 1 Speed: {sO_TSUNAMI.phase1Speed}, Phase 2 Speed: {sO_TSUNAMI.phase2Speed}");
    }

    protected void Update()
    {
        if (!isLoadC)
        {
            this.LoadEndPoint();
            this.isLoadC = true;
        }

        this.CheckEndPoint();
    }

    private void LoadEndPoint()
    {
        if (this.endPoint != null) return;
        this.endPoint = FindAnyObjectByType<EndPoint>();
    }

    private void CheckEndPoint()
    {
        if (this.endPoint != null && this.endPoint.isEnd)
        {
            IncreaseLevel();
            Debug.Log($"Level mới: {currentLevel}, Phase 1 Speed: {sO_TSUNAMI.phase1Speed}, Phase 2 Speed: {sO_TSUNAMI.phase2Speed}");
        }
    }

    private void IncreaseLevel()
    {
        if (currentLevel >= maxLevel)
        {
            Debug.Log("Đã đạt level tối đa!");
            return;
        }

        currentLevel++;
        sO_TSUNAMI.phase1Speed = Mathf.Lerp(initialPhase1Speed, maxPhase1Speed, (float)currentLevel / maxLevel);
        sO_TSUNAMI.phase2Speed = Mathf.Lerp(initialPhase2Speed, maxPhase2Speed, (float)currentLevel / maxLevel);
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetFloat("Phase1Speed", sO_TSUNAMI.phase1Speed);
        PlayerPrefs.SetFloat("Phase2Speed", sO_TSUNAMI.phase2Speed);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        sO_TSUNAMI.phase1Speed = PlayerPrefs.GetFloat("Phase1Speed", sO_TSUNAMI.phase1Speed);
        sO_TSUNAMI.phase2Speed = PlayerPrefs.GetFloat("Phase2Speed", sO_TSUNAMI.phase2Speed);
    }
}
