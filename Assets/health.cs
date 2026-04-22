using System.Collections;
using UnityEngine;

public class health : MonoBehaviour
{
    private float AllHealth = 10;

    public float maxHealth = 10;

    public bool invincibility;

    public delegate void OnHealthChangedHandler(float newHealth, float amountChanged);
    public event OnHealthChangedHandler OnHealthChanged;

    public delegate void OnHealthInitializedHandler(float newHealth);
    public event OnHealthInitializedHandler OnHealthInitialized;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        OnHealthInitialized?.Invoke(AllHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDamage(float damage)
    {
        if (!invincibility && damage > 0)
        {
            AllHealth -= damage;
            OnHealthChanged?.Invoke(AllHealth, damage);
            //Debug.Log(AllHealth);
            invincibility = true;
            StartCoroutine(ResetInvincibility(2));


            if (AllHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (damage < 0)
        {
            AllHealth -= damage;
            OnHealthChanged?.Invoke(AllHealth, damage);
        }
    }
     IEnumerator ResetInvincibility(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        invincibility = false;
        Debug.Log("Reset");
    }
}