using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    AudioSource audioSrc;

    public ProjectileBehavior ProjectilePrefab;
    public Transform LaunchOffset;

    bool isMoving = false;

    // collect references
    void Start() 
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
        manaRegen = 3f;
        audioSrc = GetComponent<AudioSource> ();
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

        if (VertInput != 0 || HorInput != 0) {
            isMoving = true;
        } else {isMoving = false;}

        if (isMoving == true) {
            if (!audioSrc.isPlaying) {
            audioSrc.Play();
            }
        } else {audioSrc.Stop();}

        if (Input.GetAxis("Horizontal") < 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Horizontal") > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
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

        if (currentHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (currentMana < 0) {
            currentMana = 0;
        }

        if(Input.GetButtonDown("Fire1")) 
        {
            Instantiate(ProjectilePrefab,LaunchOffset.position, LaunchOffset.rotation);
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

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.gameObject.CompareTag("Enemy")) {
                TakeDamage(1);
            }
        }

    void FixedUpdate()
    {
        
    }
}