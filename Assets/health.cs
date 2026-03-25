using UnityEngine;

public class health : MonoBehaviour
{
    private float AllHealth = 10;

    public float maxHealth = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        AllHealth -= damage;
        Debug.Log(AllHealth);

        if (AllHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
