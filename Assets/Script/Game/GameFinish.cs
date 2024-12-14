using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : NewMonoBehaviour
{
    [SerializeField] protected GameManager gameManager;
    [SerializeField] protected SO_GameFinish sO_GameFinish;
    [SerializeField] protected SO_INDEX sO_INDEX;
    protected bool isGameInitialized;
    protected override void Start()
    {
        base.Start();
        this.isGameInitialized = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameManager();
    }
    protected void Update()
    {
        this.ShowPanel();
        this.PointEndGame();
        this.BtnGetPoint();
    }
    protected void FixedUpdate()
    {
        
    }
    private void LoadGameManager()
    {
        if(this.gameManager != null) return;
        this.gameManager = gameObject.GetComponentInParent<GameManager>();
    }

    private void ShowPanel()
    {   
        if(this.gameManager._tsunamiAT.isEnd)
        {
            this.gameManager._uiController._uIPanel._uIPanelEndGame.gameObject.SetActive(true);
            this.TextBtnEndGame();
            this.TextFail();
        }
        if(this.gameManager._endPoint.isEnd)
        {
             this.gameManager._uiController._uIPanel._uIPanelEndGame.gameObject.SetActive(true);
             this.TextBtnEndGame();
             TextWin();
        }
    }

    private void TextBtnEndGame()
    {
        this.gameManager._uiController._uIPanel._uIPanelEndGame._btnGetToMenu._textMeshPro.text = "Get " + this.gameManager._checkAnimal.CountPoint + " $";
    }
    private void TextFail()
    {
        this.gameManager._uiController._uIPanel._uIPanelEndGame._textGameEndGame._textMeshPro_game.text = "FAIL";
    }
    private void TextWin()
    {
        this.gameManager._uiController._uIPanel._uIPanelEndGame._textGameEndGame._textMeshPro_game.text = "WIN";
    }
    
    private void PointEndGame(){
        if(this.gameManager._endPoint.isEnd)
        {
            this.gameManager._checkAnimal.CountPoint = 500f;
        }
    }

    private void BtnGetPoint()
    {
        if(!isGameInitialized)
        {
            this.gameManager._uiController._uIPanel._uIPanelEndGame._btnGetToMenu._button.onClick.AddListener(this.GetCoinToSO);
            isGameInitialized = true;
        }
    }
    private void GetCoinToSO()
    {
        this.sO_INDEX.Money += this.gameManager._checkAnimal.CountPoint;  
        PlayerPrefs.SetFloat("MoneyA",this.sO_INDEX.Money);  
        this.gameManager._endPoint.isEnd = false;
        this.gameManager._tsunamiAT.isEnd = false;
        this.ChangeScenes();
           
    }

    private void ChangeScenes()
    {
        SceneManager.LoadScene("lv0");
    }
}