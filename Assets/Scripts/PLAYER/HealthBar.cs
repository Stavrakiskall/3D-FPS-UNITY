using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public float health;

    public float timer;

    public float maxHealth = 100f;

    public float speed = 2f;
    public Image fronthealthbar;
    public Image backhealthbar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);// CLAMP = 0<health < maxhealth
        UpdateHealthUI();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(10);
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = fronthealthbar.fillAmount;
        float fillB = backhealthbar.fillAmount;
        float percentage = health / maxHealth;
        if(fillB > percentage)// gia otan faw damage
        {
            fronthealthbar.fillAmount = percentage;
            backhealthbar.color = Color.red;
            timer += Time.deltaTime;
            float completeTime =  timer / speed;
            backhealthbar.fillAmount = Mathf.Lerp(fillB, percentage, completeTime);
            //lerp (a,b,t) = smooth kinisi apo to a sto b se xrono t
            
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        timer = 0f;
    }
}
