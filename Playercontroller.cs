using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    GameObject flag;
    GameObject arrow;
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 620.0f;
    float walkForce = 35.0f;
    float maxWalkSpeed = 2.0f;
   // float threshold = 0.2f;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.flag = GameObject.Find("flag");
        this.arrow = GameObject.Find("arrow");
    }

    void Update()
    {
        // 점프한다
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어 이동
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 움직이는 방향에 따라 반전한다
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어의 속도에 맞춰서 애니메이션 속도를 바꾼다
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // 플레이어가 화면 밖으로 나갔다면 처음부터
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    // 골 도착
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "flag") //깃발에 닿였을 때
        {
            Debug.Log("골");
            SceneManager.LoadScene("ClearDirector");
        }
        
    }
}
