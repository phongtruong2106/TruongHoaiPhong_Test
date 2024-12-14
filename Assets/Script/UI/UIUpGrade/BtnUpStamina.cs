using UnityEngine;

public class BtnUpStamina : BtnGame
{

    protected override void Start()
    {
        base.Start();
        UpdateButtonText();

    }
    
    protected void Update()
    {
        if(!isLoad)
        {      
            LoadSpeed();
            this.isLoad = true;
        }
    }
    public virtual void UpGrade()
    {
        if (sO_IndexUp == null) return;
        if (sO_INDEX.Money >= sO_IndexUp.currentUpgradeCost)
        {
            sO_IndexUp.Stamina += 2;
            sO_INDEX.Money -= sO_IndexUp.currentUpgradeCost;
            sO_IndexUp.currentUpgradeCost = Mathf.CeilToInt(sO_IndexUp.currentUpgradeCost * 1.2f);
            SaveSpeed();
            this.SaveMOneya();
            UpdateButtonText();
        }
        else
        {
            // Debug.Log("Không đủ tiền để nâng cấp!");
        }
    }
      private void SaveSpeed()
    {
        PlayerPrefs.SetFloat("Stamina", sO_IndexUp.Speed);
        PlayerPrefs.SetFloat("UpgradeCostSt", sO_IndexUp.currentUpgradeSpeed);
        PlayerPrefs.Save(); // Save changes
    }

    // Load saved money and upgrade cost
    private void LoadSpeed()
    {
        if (PlayerPrefs.HasKey("Stamina"))
        {
            sO_IndexUp.Money = PlayerPrefs.GetFloat("Stamina");
        }

        if (PlayerPrefs.HasKey("UpgradeCostSt"))
        {
            sO_IndexUp.currentUpgradeMoney = PlayerPrefs.GetFloat("UpgradeCostSt");
        }
    }
    private void UpdateButtonText()
    {
         textMeshPro.text = $"Stamina x{sO_IndexUp.Stamina}\nCost: {sO_IndexUp.currentUpgradeCost} Money";
    }
}