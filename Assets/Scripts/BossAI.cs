using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    // Start is called before the first frame update
    public BossHealthBar healthBar;

    public Animator animator;
    public int maxHealth = 300;
    public int currentHealth;

    public GameObject bullet;
    float fireRate;
    float nextFire;
    
    public Transform launchOffset;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
            CheckIfTimeToFire();
            if (currentHealth <= 0) {
                animator.SetTrigger("Die");
                Destroy(gameObject, 1);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.gameObject.CompareTag("projectile")) {
                TakeDamage(20);
            }
        }
    void TakeDamage (int damage) 
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        }
    
    void CheckIfTimeToFire() {
        if (Time.time > nextFire) {
            Instantiate (bullet, launchOffset.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}

