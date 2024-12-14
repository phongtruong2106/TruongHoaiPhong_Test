using UnityEngine;

public class BtnUpMoney : BtnGame
{
    protected override void Start()
    {
        base.Start();
        UpdateButtonText();
        this.LoadMoney();
        this.LoadMoneya();
    }
    public virtual void UpGrade()
    {
        if (sO_IndexUp == null) return;
        if (sO_INDEX.Money >= sO_IndexUp.currentUpgradeMoney)
        {
            sO_IndexUp.Money += 10;
            sO_INDEX.Money -= sO_IndexUp.currentUpgradeMoney;
            sO_IndexUp.currentUpgradeMoney = Mathf.CeilToInt(sO_IndexUp.currentUpgradeMoney * 1.2f);
            SaveMoney();
            SaveMOneya();
            UpdateButtonText();
        }
        else
        {
            // Debug.Log("Không đủ tiền để nâng cấp!");
        }
    }
    private void SaveMoney()
    {
        PlayerPrefs.SetFloat("Money", sO_IndexUp.Money);
        PlayerPrefs.SetFloat("UpgradeCost", sO_IndexUp.currentUpgradeMoney);
        PlayerPrefs.Save(); // Save changes
    }

    // Load saved money and upgrade cost
    private void LoadMoney()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            sO_IndexUp.Money = PlayerPrefs.GetFloat("Money");
        }

        if (PlayerPrefs.HasKey("UpgradeCost"))
        {
            sO_IndexUp.currentUpgradeMoney = PlayerPrefs.GetFloat("UpgradeCost");
        }
    }
    private void UpdateButtonText()
    {
         textMeshPro.text = $"Money x{sO_IndexUp.Money}\nCost: {sO_IndexUp.currentUpgradeMoney} Money";
    }
}