using Unity.VisualScripting;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float HealingValue = -5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float heal)
    {
        HealingValue += heal;
        Debug.Log(HealingValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<health>().AddDamage(HealingValue);

        if (collision.GetComponent<health>() != null)
            // :3 meow if if 
            Destroy(gameObject);
       

    }
    //Debug.Log(currentHealth)

    
    
}
