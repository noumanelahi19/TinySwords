using UnityEngine;

public class Mountain_Exit : MonoBehaviour
{
    public Collider2D[] heightCollider;
    public Collider2D[] boundaryCollider;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Collider2D collider in heightCollider)
            {
                collider.enabled = true;
            }
            foreach (Collider2D collider in boundaryCollider)
            {
                collider.enabled = false;
            }
        }
    }
}
