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
    public float reducetime;

    private void Start()
    {
        clickManager = GetComponent<ClickManager>();
        autoClick = GetComponent<AutoClick>();
    }

    public void MyUpgrade()
    {
        if (upgradeCost < clickManager.coin)
        {
            clickManager.coin -= upgradeCost;
            upgradeCost += Mathf.CeilToInt(upgradeCost * 0.25f); // ���÷� ���� ������ ������ �� �ֽ��ϴ�.
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
            AutoupgradeCost = Mathf.CeilToInt(AutoupgradeCost * 1.5f); // ���÷� ���׷��̵� ��� ������ ������ �� �ֽ��ϴ�.

            // AutoClick Ŭ���������� autoClickData�� ���� ������ �� �����Ƿ� ClickManager�� �޼��带 ���� ó���մϴ�.
            clickManager.UpdateAutoClickData(reducetime);

            UpdateUpgradeText();
        }
    }

    public void UpdateUpgradeText()
    {
        upgradeCostText.text = upgradeCost.ToString();
        upgradeLevelText.text = upgradeLevel.ToString();
    }
}
