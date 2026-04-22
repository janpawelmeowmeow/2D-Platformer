using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float points = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCoin(float GiveCoin)
    {
        points = GiveCoin;
        //Debug.Log(GiveCoin);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CoinComponent>().AddPoints(points);
        Destroy(gameObject);
    }






}
