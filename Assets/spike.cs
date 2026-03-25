using UnityEngine;
using UnityEngine.UIElements;

public class spike : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Damage = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<health>().AddDamage(Damage);
    }
}
