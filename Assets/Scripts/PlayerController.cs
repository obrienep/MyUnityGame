using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float CharacterSpeed = 1.0f;
    private Vector2 InputDir;

    public Rigidbody2D PlayerPhysics;
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public ManaBar manaBar;

    public int maxMana = 100;
    public float currentMana;
    public float manaRegen = 3f;

    // collect references
    void Start() 
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
        manaRegen = 3f;
    }
    void Awake()
    {

        PlayerPhysics = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        float VertInput = Input.GetAxis("Vertical");
        float HorInput = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x = position.x + CharacterSpeed * HorInput * Time.deltaTime;
        position.y = position.y + CharacterSpeed * VertInput * Time.deltaTime;
        transform.position = position;
        InputDir = new Vector2(HorInput, VertInput).normalized;
        Vector3 characterScale = transform.localScale;

        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0) {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        animator.SetFloat("Speed", (Mathf.Abs(VertInput) + Mathf.Abs(HorInput)));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ConsumeMana(20);
        }
        if (currentMana < maxMana) 
        {   
            currentMana += manaRegen * Time.deltaTime;
            manaBar.setMana(Mathf.RoundToInt(currentMana));
        }

        if (currentMana > maxMana) 
        {
            currentMana = maxMana;
        }
    }

    void TakeDamage (int damage) 
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);
    }

        void ConsumeMana (int cost) 
    {
        currentMana -= cost;

        manaBar.setMana(Mathf.RoundToInt(currentMana));

    }

    void FixedUpdate()
    {
        
    }
}