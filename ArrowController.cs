using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowController : MonoBehaviour
{

    GameObject cat;
    GameObject cloud;
    GameObject arrow;
    Rigidbody2D rbody2D;

    void Start()
    {
        this.cat = GameObject.Find("cat");
        this.cloud = GameObject.Find("cloud");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.01f, 0); //화살 낙하 속도

        if (transform.position.y < -5.0f) //화면밖으로 나가면 화살 소멸 
        {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "cat") //화살이 고양이에게 닿였을때
        {          
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Destroy(gameObject); //화살 소멸
        }
    }
 
   
}

