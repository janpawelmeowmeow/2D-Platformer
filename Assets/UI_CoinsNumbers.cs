using System;
using TMPro;
using UnityEngine;

public class UI_CoinsNumbers : MonoBehaviour
{


    public CoinComponent Coin;
    public TextMeshProUGUI textComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Coin.CoinChanged += CoinChanged;
        Coin.CoinInitialized += CoinInitialized;


    }

    private void CoinInitialized(float newCoin)
    {
        textComponent.text = newCoin.ToString();
    }

    private void CoinChanged(float newCoin, float amountChanged)
    {
        textComponent.text = newCoin.ToString();
        //Debug.Log(newCoin + ":" + amountChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
