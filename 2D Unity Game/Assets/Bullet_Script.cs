using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet_Script : MonoBehaviour
{
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Count and move

            if (counter >= 10)
            {
                SceneManager.LoadScene(1);
                counter = 0f;
            }

            if (counter >= 20)
            {
                SceneManager.LoadScene(2);
                counter = 0f;
            }
        }
    }

}
