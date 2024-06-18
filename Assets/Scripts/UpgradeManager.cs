using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    private ClickManager clickManager;
    public TextMeshProUGUI upgradeLevelText;
    public TextMeshProUGUI upgradeCostText;

    [Header("My Click")]
    public int upgradeCost;
    public int upgradeLevel = 1;

    [Header("Auto Click")]
    public List<AutoClickUpgrade> autoClickUpgrades;

    private void Awake()
    {
        clickManager = FindObjectOfType<ClickManager>();
    }

    public void MyUpgrade()
    {
        if (clickManager.coin >= upgradeCost)
        {
            clickManager.coin -= upgradeCost;
            upgradeCost += Mathf.CeilToInt(upgradeCost * 0.25f);
            upgradeLevel++;
            clickManager.myClickCoin += 1;
            clickManager.UpdateText();
            UpdateUpgradeText();
        }
    }

    public void OnAutoClickUpgradeButton(int dataIndex)
    {
        UpgradeAutoClick(dataIndex);
    }

    public void UpgradeAutoClick(int dataIndex)
    {
        AutoClickUpgrade upgrade = autoClickUpgrades[dataIndex];
        AutoClickData data = upgrade.autoClickData;

        if (clickManager.coin >= data.upgradeCost)
        {
            clickManager.coin -= data.upgradeCost;
            data.upgradeLevel++;
            data.upgradeCost = Mathf.CeilToInt(data.upgradeCost * 1.5f);

            if (data.clickDelay > 0)
            {
                data.clickDelay -= data.reducetime;
            }

            clickManager.UpdateText();
            UpdateUpgradeText();
        }
    }

    public void UpdateUpgradeText()
    {
        upgradeCostText.text = upgradeCost.ToString();
        upgradeLevelText.text = upgradeLevel.ToString();

        foreach (var upgrade in autoClickUpgrades)
        {
            upgrade.upgradeCostText.text = upgrade.autoClickData.upgradeCost.ToString();
            upgrade.upgradeLevelText.text = upgrade.autoClickData.upgradeLevel.ToString();
        }
    }
}
