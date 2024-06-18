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
    public float timer = 0f;

    public AutoClickData[] autoClickData;

    public void OnClick()
    {
        coin += myClickCoin;
        UpdateText();
    }

    public void AutoClick()
    {
        foreach (var data in autoClickData)
        {
            timer += Time.deltaTime;
            if (timer >= data.clickDelay && data.upgradeLevel > 0)
            {
                timer = 0f;
                coin += data.autoClickCoin * data.upgradeLevel;
            }
        }
        UpdateText();
    }


    public void UpdateText()
    {
        coinText.text = coin.ToString();
        perClickCoinText.text = myClickCoin.ToString();
        autoClickCoinText.text = autoClickCoin.ToString();
    }
}
