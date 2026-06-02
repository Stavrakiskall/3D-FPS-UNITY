using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    private float maxHealth = 100f;

    private float health;
    
    public Canvas canvas;
    public Slider healthSlider;
    public Image healthfill;

    public float lerpSpeed = 3f;
    
    private float targetHealth;
    public GameObject healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
     targetHealth = Mathf.Lerp(targetHealth, health, lerpSpeed * Time.deltaTime);
     if (healthfill != null)
     {
         healthSlider.value = targetHealth;
         
     }

     if (targetHealth <= 0)
     {
         Destroy(gameObject);
     }
    }

    void LateUpdate()
    {
        healthBar.transform.LookAt(Camera.main.transform);
        healthBar.transform.Rotate(0, 180, 0);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
