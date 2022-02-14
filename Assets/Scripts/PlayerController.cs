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

    // collect references
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

        

    }

    void FixedUpdate()
    {

    }
}