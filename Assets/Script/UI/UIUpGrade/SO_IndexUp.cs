using UnityEngine;

[CreateAssetMenu(menuName = "My project/SO_IndexUp")]
public class SO_IndexUp : ScriptableObject
{
    public float Money;
    public float Speed;
    public float Stamina;
    public float currentUpgradeCost = 50;
    public float currentUpgradeMoney = 50;
    public float currentUpgradeSpeed = 50;
}