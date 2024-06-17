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
            upgradeCost += Mathf.CeilToInt(upgradeCost * 0.25f); // 예시로 증가 비율을 조정할 수 있습니다.
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
            AutoupgradeCost = Mathf.CeilToInt(AutoupgradeCost * 1.5f); // 예시로 업그레이드 비용 증가를 조정할 수 있습니다.

            // AutoClick 클래스에서는 autoClickData에 직접 접근할 수 없으므로 ClickManager의 메서드를 통해 처리합니다.
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
