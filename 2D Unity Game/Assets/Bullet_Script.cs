using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet_Script : MonoBehaviour
{
    int counter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (counter == 10 && SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    SceneManager.LoadScene(1);

        //}

        //if (counter == 15 && SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    SceneManager.LoadScene(2);
        //}

        //if (counter == 20 && SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    SceneManager.LoadScene(3);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //// Count and move
            //counter += 1;

            //Debug.Log(counter);
        }
    }


}
