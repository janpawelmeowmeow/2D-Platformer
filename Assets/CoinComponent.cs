using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float points;

    public delegate void OnCoinChangedHandler(float newCoin, float amountChanged);
    public event OnCoinChangedHandler CoinChanged;

    public delegate void OnCoinInitializedHandler(float newCoin);
    public event OnCoinInitializedHandler CoinInitialized;
    public void AddPoints(float amount) 
    {
        points += amount;
        CoinInitialized?.Invoke(points);
    }



    void Awake()
    {
        AddPoints(0);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}

