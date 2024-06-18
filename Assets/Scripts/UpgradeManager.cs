using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private ClickManager clickManager;
    public TextMeshProUGUI upgradeLevelText;
    public TextMeshProUGUI upgradeCostText;

    private AutoClickData autoClickData;

    [Header("My Click")]
    public int upgradeCost;
    public int upgradeLevel = 1;

    private void Awake()
    {
        clickManager = FindObjectOfType<ClickManager>();
    }

    public void MyUpgrade()
    {
        if (upgradeCost < clickManager.coin)
        {
            clickManager.coin -= upgradeCost;
            upgradeCost += Mathf.CeilToInt(upgradeCost * 0.25f);
            upgradeLevel++;
            clickManager.myClickCoin += 1;
            clickManager.UpdateText();
            UpdateUpgradeText();
        }
    }

    public void OnAutoClickUpgradeButton()
    {
        UpgradeAutoClick(autoClickData.autoClickDataIndex);
    }

    public void UpgradeAutoClick(int dataIndex)
    {
        AutoClickData data = clickManager.autoClickData[dataIndex];

        if (clickManager.coin >= data.upgradeCost)
        {
            clickManager.coin -= data.upgradeCost;
            data.upgradeLevel++;
            data.upgradeCost = Mathf.CeilToInt(data.upgradeCost * 1.5f); 

            if(data.clickDelay > 0)
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
    }
}
