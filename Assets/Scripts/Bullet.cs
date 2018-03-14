using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        /*int otherLayer = other.gameObject.layer;

        if (otherLayer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(other.gameObject);
        }*/

        Destroy(gameObject);
    }



}