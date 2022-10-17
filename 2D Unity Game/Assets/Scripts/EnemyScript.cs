using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public GameObject Enemy;
    [SerializeField] public Transform gun;
    public float move = 0;
    [SerializeField] Transform player;
    Rigidbody2D rbGun;
    Vector3 position = new Vector3(0f, 0f);

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
    }

    void OnLook()
    {
        gun.eulerAngles = new Vector3(player.position.x, player.position.y, player.position.x + (player.position.y * -1) * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(Enemy);
        }
    }
}
