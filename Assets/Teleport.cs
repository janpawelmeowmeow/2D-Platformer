using UnityEngine;

public class Teleport : MonoBehaviour
{


    public Transform position;
    //mreow
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = position.position;
        

    }



}
