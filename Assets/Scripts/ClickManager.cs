using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI perClickCoinText;
    public TextMeshProUGUI autoClickCoinText;

    public int coin = 0;
    public int myClickCoin = 1;
    public int autoClickCoin = 1;

    public void OnClick()
    {
        coin += myClickCoin;
        UpdateText();
    }

    public void AutoClick()
    {
        coin += autoClickCoin;
        UpdateText() ;
    }

    public void UpdateText()
    {
        coinText.text = coin.ToString();
        perClickCoinText.text = myClickCoin.ToString();
        autoClickCoinText.text = autoClickCoin.ToString();
    }
}
