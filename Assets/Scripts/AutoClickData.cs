using UnityEngine;

[CreateAssetMenu(fileName = "AutoClickData", menuName = "ScriptableObjects/AutoClickData", order = 1)]
public class AutoClickData : ScriptableObject
{
    public int autoClickCoin;
    public float clickDelay;
    public int upgradeCost;
    public int upgradeLevel;

    [Header("Upgrade Manager Settings")]
    public int autoClickDataIndex = 0;
    public float reducetime = 0.1f;
}
