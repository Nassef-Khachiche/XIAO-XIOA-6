using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_script : MonoBehaviour
{
    [SerializeField] public Transform gun;
    public float move = 0;
    Vector3 mousePosition;
    Rigidbody2D rb;
    Vector3 position = new Vector2(0f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnLook();
    }

    void OnLook() 
    {
        mousePosition = Camera.main.ViewportToWorldPoint(mousePosition);
        gun.eulerAngles = new Vector3(gun.rotation.x, gun.rotation.y, mousePosition.z);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
