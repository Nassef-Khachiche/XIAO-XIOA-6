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
    int counter;
    Vector3 pForce;

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
        CheckNextLevel();
    }

    public void CheckNextLevel() 
    {
        if (counter == 10 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);

        }

        if (counter == 15 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }

        if (counter == 20 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3);
        }
    }

    void MyCoroutine()
    {
        Vector3 power = new Vector3(player.position.x, 3f, player.position.z);
        float randnum = Random.Range(0.001f, 0.005f);
        time += randnum;
        if (time > 2f)
        {
            duplicateBullet = Instantiate(bullet, gun.position, gun.rotation);
            dupedBullet = duplicateBullet.GetComponent<Rigidbody2D>();

            if (transform.localScale.x == -1f)
            {
                dupedBullet.AddForce((power * -1) * -100);
            }
            else
            {
                dupedBullet.AddForce((power * -1) * -100);
            }
            time = 0;
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
            counter = counter + 1;
            Debug.Log(counter);
            float rnd = Random.Range(-5f, 15f);
            Vector3 spawnpoint = new Vector3(rnd, 10f, 0f);
            Enemy.transform.position = spawnpoint;
        }
    }
}
