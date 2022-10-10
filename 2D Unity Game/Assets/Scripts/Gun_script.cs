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
    Vector3 position = new Vector3(0f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {
        OnLook();
    }

    void OnLook()
    {
        mousePosition = Input.mousePosition;
        mousePosition  = Camera.main.ScreenToWorldPoint(mousePosition);
        gun.eulerAngles = new Vector3(mousePosition.x, mousePosition.y, mousePosition.x + mousePosition.y * 15);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
