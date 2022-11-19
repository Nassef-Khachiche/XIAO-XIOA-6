using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        rbGun = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        MyCoroutine();
        Debug.Log(time);
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


    void OnLook()
    {
        gun.eulerAngles = new Vector3(player.position.x, player.position.y, player.position.x + (player.position.y * -1) * 10);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
    //        Destroy(Enemy);
    //    }
    //}
}
