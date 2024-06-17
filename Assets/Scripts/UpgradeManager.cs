using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public ClickManager clickManager;
    public TextMeshProUGUI upgradeLevelText;
    public TextMeshProUGUI upgradeCostText;
    public int upgradeCost;
    public int upgradeLevel = 1;

    public void OnUpgrade()
    {
        if(upgradeCost < clickManager.coin)
        {
            clickManager.coin -= upgradeCost;
            upgradeCost += Mathf.CeilToInt(1.25f);
            upgradeLevel++;
            clickManager.upgradeClick += 1;
            clickManager.UpdateText();
            UpdateUpgradeText();
        }
    }

    public void UpdateUpgradeText()
    {
        upgradeCostText.text = upgradeCost.ToString();
        upgradeLevelText.text = upgradeLevel.ToString();
    }
}
