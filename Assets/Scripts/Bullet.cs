using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("hit player");
            hitTransform.GetComponent<HealthBar>().TakeDamage(20);
        }
        if (hitTransform.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            hitTransform.GetComponent<EnemyHealth>().TakeDamage(20);
        }
        Destroy(gameObject);
    }
}
