using UnityEngine;

public class BtnUpSpeed : BtnGame
{
    [SerializeField] protected SO_PLAYER sO_PLAYER;
    protected override void Start()
    {
        base.Start();
        UpdateButtonText();
        LoadSpeed();
    }
    public virtual void UpGrade()
    {
        if (sO_IndexUp == null) return;
        if (sO_INDEX.Money >= sO_IndexUp.currentUpgradeSpeed)
        {
            sO_IndexUp.Speed += 3;
            sO_PLAYER._moveSpeed += sO_IndexUp.Speed;
            sO_INDEX.Money -= sO_IndexUp.currentUpgradeSpeed;
            sO_IndexUp.currentUpgradeSpeed = Mathf.CeilToInt(sO_IndexUp.currentUpgradeSpeed * 1.2f);
            SaveSpeed();
            SaveMOneya();
            UpdateButtonText();
        }
        else
        {
            // Debug.Log("Không đủ tiền để nâng cấp!");
        }
    }

    private void SaveSpeed()
    {
        PlayerPrefs.SetFloat("Speed", sO_IndexUp.Speed);
        PlayerPrefs.SetFloat("UpgradeCostS", sO_IndexUp.currentUpgradeSpeed);
        PlayerPrefs.Save(); // Save changes
    }

    
    // Load saved money and upgrade cost
    private void LoadSpeed()
    {
        if (PlayerPrefs.HasKey("Speed"))
        {
            sO_IndexUp.Money = PlayerPrefs.GetFloat("Speed");
        }

        if (PlayerPrefs.HasKey("UpgradeCostS"))
        {
            sO_IndexUp.currentUpgradeMoney = PlayerPrefs.GetFloat("UpgradeCostS");
        }
    }
    private void UpdateButtonText()
    {
         textMeshPro.text = $"Speed x{sO_IndexUp.Speed}\nCost: {sO_IndexUp.currentUpgradeSpeed} Money";
    }
}