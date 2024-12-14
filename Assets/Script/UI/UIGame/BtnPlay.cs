using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlay : BtnGame
{
    protected bool isPlay;
    protected override void Start()
    {
        this.isPlay = false;
    }
    
    protected void Update()
    {
        this.Play();
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
}