using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
 		healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        healthBar.value = currentHealth;

        if (currentHealth == 0)
        {
            DestroyCastle();
        }
    }
	void DestroyCastle()
    {
        Debug.Log("Castillo destruido!");
        Destroy(gameObject);
    }
   
}
