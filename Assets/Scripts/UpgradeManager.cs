using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private ClickManager clickManager;
    private AutoClick autoClick;
    public TextMeshProUGUI upgradeLevelText;
    public TextMeshProUGUI upgradeCostText;

    [Header("My Click")]
    public int upgradeCost;
    public int upgradeLevel = 1;

    [Header("Auto Click")]
    public int AutoupgradeCost;
    public int AutoupgradeLevel = 1;
    public float reducetime;

    public void MyUpgrade()
    {
        if(upgradeCost < clickManager.coin)
        {
            clickManager.coin -= upgradeCost;
            upgradeCost += Mathf.CeilToInt(1.25f);
            upgradeLevel++;
            clickManager.myClickCoin += 1;
            clickManager.UpdateText();
            UpdateUpgradeText();
        }
    }

    public void OnAutoClickUpgrade()
    {
        if (clickManager.coin >= AutoupgradeCost)
        {
            clickManager.coin -= AutoupgradeCost;
            AutoupgradeCost = Mathf.CeilToInt(AutoupgradeCost * 1.5f);

            if(autoClick.rangeTime > 0)
            {
                autoClick.rangeTime -= reducetime;
            }

            UpdateUpgradeText();
        }
    }

    public void UpdateUpgradeText()
    {
        upgradeCostText.text = upgradeCost.ToString();
        upgradeLevelText.text = upgradeLevel.ToString();
    }
}
