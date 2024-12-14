using UnityEngine;

public class UIPanel : NewMonoBehaviour
{
    [SerializeField] protected UIPanelEndGame uIPanelEndGame;
    public UIPanelEndGame _uIPanelEndGame => uIPanelEndGame; 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIPanelGame();
    }

    private void LoadUIPanelGame()
    {
        if(this.uIPanelEndGame != null) return;
        this.uIPanelEndGame = gameObject.GetComponentInChildren<UIPanelEndGame>();
    }
}