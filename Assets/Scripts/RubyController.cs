using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    [SerializeField]
    private float CharacterSpeed = 1.0f;
    private Vector2 InputDir;

    public Rigidbody2D PlayerPhysics;

    // collect references
    void Awake()
    {

        PlayerPhysics = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        float VertInput = Input.GetAxis("Vertical");
        float HorInput = Input.GetAxis("Horizontal");
        InputDir = new Vector2(HorInput, VertInput).normalized;

    }

    void FixedUpdate()
    {

        Vector2 WhereAmI = PlayerPhysics.position;
        Vector2 WhereTo = WhereAmI + (InputDir * CharacterSpeed) * Time.fixedDeltaTime;
        PlayerPhysics.MovePosition(WhereTo);

    }
}