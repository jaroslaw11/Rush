using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 25;

    private void OnTriggerEnter(Collider _other)
    {
        var other = _other.gameObject;
        // if enemy
        if (other.layer == 26)
        {
            var enemy = other.GetComponent<AIHealth>();
            enemy.TakeDamage(damage);
            GetComponent<Collider>().enabled = false;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.layer == 9)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 30, 0), ForceMode.Impulse);
        }
    }
}
