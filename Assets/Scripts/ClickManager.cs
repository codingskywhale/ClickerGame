using TMPro;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI perClickCoinText;
    public TextMeshProUGUI autoClickCoinText;

    public int coin = 0;
    public int myClickCoin = 1;
    public int autoClickCoin = 1;

    public AutoClickData[] autoClickData;

    public void OnClick()
    {
        coin += myClickCoin;
        UpdateText();
    }

    public void AutoClick()
    {
        foreach (var button in autoClickData)
        {
            if (Time.time >= button.clickDelay && button.upgradeLevel > 0)
            {
                coin += button.autoClickCoin * button.upgradeLevel;
                button.clickDelay = Time.time + button.clickDelay;
            }
        }
        UpdateText();
    }

    public void UpgradeAutoClick(int buttonIndex)
    {
        AutoClickData button = autoClickData[buttonIndex];

        if (coin >= button.upgradeCost)
        {
            coin -= button.upgradeCost;
            button.upgradeCost *= 2;
            button.upgradeLevel++;
            UpdateText();
        }
    }

    public void UpdateAutoClickData(float reducetime)
    {
        foreach (var button in autoClickData)
        {
            if (button.upgradeLevel > 0)
            {
                button.clickDelay -= reducetime; // 자동 클릭 간격을 감소시킵니다.
            }
        }
    }

    public void UpdateText()
    {
        coinText.text = coin.ToString();
        perClickCoinText.text = myClickCoin.ToString();
        autoClickCoinText.text = autoClickCoin.ToString();
    }
}
