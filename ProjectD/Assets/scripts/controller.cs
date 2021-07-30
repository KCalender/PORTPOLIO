using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Rigidbody rb;
    float speed = 10f;
    float runSpeed = 20f;
    Animator Animator;
    Transform camera;
    void Start()
    {
        camera = GetComponentInChildren<Transform>().Find("cameraLook");
        rb = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movecontrol();
    }

    // 키보드 입력으로 캐릭터 조작
    // input.getaxis("horizontal");
    void movecontrol()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(xMove, 0.0f, zMove);
        if (input == Vector3.zero)
            return;

        Vector3 getVel = new Vector3(xMove, 0, zMove);
        if (getVel != Vector3.zero)
        {
            Animator.SetBool("walk", true);

            rb.velocity = getVel * speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Animator.SetBool("run", true);
                rb.velocity = getVel * runSpeed;
            }
            else
                Animator.SetBool("run", false);

        }
        else
        {
            Animator.SetBool("run", false);
            Animator.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Animator.SetTrigger("jump");
        }

        Debug.Log("rb 각: "+rb.rotation.eulerAngles);
        
        rb.rotation = Quaternion.LookRotation(input).normalized;
    }
    
}
