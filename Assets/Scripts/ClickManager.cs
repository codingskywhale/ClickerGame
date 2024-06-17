using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI perClickCoin;

    public int coin = 0;
    public int upgradeClick = 1;

    public void OnClick()
    {
        coin += upgradeClick;
        UpdateText();
    }

    public void UpdateText()
    {
        coinText.text = coin.ToString();
        perClickCoin.text = upgradeClick.ToString();
    }
}
