using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    Vector2 moveInput;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }
}
