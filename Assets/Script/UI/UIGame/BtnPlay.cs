using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlay : BtnGame
{
    protected bool isPlay;
    protected int currentLevel;
    protected bool isText;
    
    protected override void Start()
    {
        this.isPlay = false;
    }
    
    protected void Update()
    {
        this.Play();
        this.LoadData();
        this.isText = false;
        this.TextLevel();
    }

    
    private void Play()
    {
        if(!this.isPlay)
        {
            this.button.onClick.AddListener(ChangeScene);
            this.isPlay = true;
        }
    }
    private void ChangeScene()
    {
         SceneManager.LoadScene("lv1");
    }

    private void TextLevel()
    {
        if(!this.isText)
        {
            this._textMeshPro.text = "Level " + currentLevel;
            this.isText = true;
        }
    }
    private void LoadData()
    {
        if(!this.isLoad)
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
            this.isLoad = true;
        }
        
    }
}