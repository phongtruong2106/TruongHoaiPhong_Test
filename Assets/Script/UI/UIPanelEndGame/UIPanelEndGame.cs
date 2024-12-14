using System;
using UnityEngine;

public class UIPanelEndGame : NewMonoBehaviour
{
    [SerializeField] protected BtnGetToMenu btnGetToMenu;
    public BtnGetToMenu _btnGetToMenu => btnGetToMenu;
    [SerializeField] protected TextGameEndGame textGameEndGame;
    public TextGameEndGame _textGameEndGame => textGameEndGame;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnGetToMenu();
        this.LoadTextGameEndGame();
    }

    private void LoadBtnGetToMenu()
    {
        if(this.btnGetToMenu != null) return;
        this.btnGetToMenu = gameObject.GetComponentInChildren<BtnGetToMenu>();
    }

    private void LoadTextGameEndGame()
    {
        if(this.textGameEndGame != null) return;
        this.textGameEndGame = gameObject.GetComponentInChildren<TextGameEndGame>();
    }
}