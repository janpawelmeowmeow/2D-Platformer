using UnityEngine;

public class KillVolume : MonoBehaviour
{
    // yellow
    private float Damage = 1000;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.GetComponent<health>().AddDamage(Damage);


    }






}
