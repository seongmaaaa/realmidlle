using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catcat : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float walkForce = 15.0f;
    float maxWalkSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -0.0f, 0); //중력 가속도 설정
        int key = 0;  //좌우 이동
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        //플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다
        this.animator.speed = speedx / 2.0f;
        if (transform.position.y < -20)
        {
            SceneManager.LoadScene("Gamesecen");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("nextscene2");
    }
}
