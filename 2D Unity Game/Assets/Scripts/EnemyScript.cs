using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private Vector3 startposition = new Vector3(1, -0.3f, 0);
    private Vector3 endposition = new Vector3(-1, -0.3f, 0);

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        //rb.AddForce(new Vector2(0, Mathf.Sin(speed * Time.deltaTime * 1) - 10f / 1f));
        transform.position = Vector3.Lerp(startposition, endposition, (Mathf.Sin(speed * Time.time) + 0.1f) / 0.1f);
        //rb.AddTorque(0.00002f, ForceMode2D.Force);
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, (Mathf.Cos(2f * Time.deltaTime) + 0.1f), transform.rotation.w);
    }
}
