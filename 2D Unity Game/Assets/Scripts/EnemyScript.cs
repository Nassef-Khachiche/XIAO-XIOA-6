using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D dupedBullet;
    GameObject duplicateBullet;
    [SerializeField] GameObject bullet;

    public float time = 0f;
    [SerializeField] public GameObject Enemy;
    [SerializeField] public Transform gun;
    public float move = 0;
    [SerializeField] Transform player;
    Rigidbody2D rbGun;
    Vector3 position = new Vector3(0f, 0f);
    private Rigidbody2D rb;


    GameObject duplicateEnemy;
    Rigidbody2D dupedEnemy;

    void Start()
    {
        rbGun = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        MyCoroutine();
        OnLook();
    }

    void MyCoroutine()
    {
        float randnum = Random.Range(0.001f, 0.005f);
        time += randnum;
        if (time > 2f)
        {
            duplicateBullet = Instantiate(bullet, gun.position, gun.rotation);
            dupedBullet = duplicateBullet.GetComponent<Rigidbody2D>();

            if (transform.localScale.x == -1f)
            {
                dupedBullet.AddForce((player.position * -1) * 100);
            }
            else
            {
                dupedBullet.AddForce((player.position * -1) * 100);
            }
            time = 0;
        }
    }

    private void FlipSprite()
    {
        bool playerHasSpeed = Mathf.Abs(dupedEnemy.velocity.x) > Mathf.Epsilon;

        if (playerHasSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(dupedEnemy.velocity.x), transform.localScale.y);
        }
    }


    void OnLook()
    {
        gun.eulerAngles = new Vector3(player.position.x, player.position.y, player.position.x + (player.position.y * -1) * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            float rnd = Random.Range(-10f, 20f);
            Vector3 spawnpoint = new Vector3(rnd, 10f, 0f);
            duplicateEnemy = Instantiate(Enemy, spawnpoint, player.rotation);
            dupedEnemy = duplicateEnemy.GetComponent<Rigidbody2D>();
            FlipSprite();

            Destroy(Enemy);
        }
    }
}
