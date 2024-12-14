using UnityEngine;

public class UIController : NewMonoBehaviour
{
    [SerializeField] protected UIPanel uIPanel;
    public UIPanel _uIPanel => uIPanel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIPanel();
    }

    private void LoadUIPanel()
    {
        if(this.uIPanel != null) return;
        this.uIPanel = FindAnyObjectByType<UIPanel>();
    }
}