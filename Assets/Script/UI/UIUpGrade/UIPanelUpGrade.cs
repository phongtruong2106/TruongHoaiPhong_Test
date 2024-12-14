using UnityEngine;

public class UIPanelUpGrade : NewMonoBehaviour
{
    [SerializeField] protected BtnUpMoney btnUpMoney;
    public BtnUpMoney _btnUpMoney => btnUpMoney;    
    [SerializeField] protected BtnUpSpeed btnUpSpeed;
    public BtnUpSpeed _btnUpSpeed => btnUpSpeed;
    [SerializeField] protected BtnUpStamina btnUpStamina;
    public BtnUpStamina _btnUpStamina => btnUpStamina;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnUpMoney();
        this.LoadBtnUpSpeed();
        this.LoadBtnUpStamina();
    }

    private void LoadBtnUpMoney()
    {
        if(this.btnUpMoney != null) return;
        this.btnUpMoney = gameObject.GetComponentInChildren<BtnUpMoney>();
    }
    private void LoadBtnUpSpeed()
    {
        if(this.btnUpSpeed != null) return;
        this.btnUpSpeed = gameObject.GetComponentInChildren<BtnUpSpeed>();
    }
    private void LoadBtnUpStamina()
    {
        if(this.btnUpStamina != null) return;
        this.btnUpStamina = gameObject.GetComponentInChildren<BtnUpStamina>();
    }

}