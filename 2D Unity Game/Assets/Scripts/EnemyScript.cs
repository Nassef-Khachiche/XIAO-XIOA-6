using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public Transform gun;
    public float move = 0;
    [SerializeField] Transform player;
    Rigidbody2D rbGun;
    Vector3 position = new Vector3(0f, 0f);

    [SerializeField] private float speed = 1.0f;
    private Vector3 startposition = new Vector3(1, -0.3f, 0);
    private Vector3 endposition = new Vector3(-1, -0.3f, 0);

    private Rigidbody2D rb;

    void Start()
    {
        rbGun = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        OnLook();
        transform.position = Vector3.Lerp(startposition, endposition, (Mathf.Sin(speed * Time.time)) / 0.1f);
    }

    void OnLook()
    {
        //rbGun.eulerAngles = new Vector3(player.position.x, player.position.y, player.position.x + player.position.y * 15);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
