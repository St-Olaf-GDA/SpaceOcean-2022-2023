using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float speed = 6f;
    bool isRight = false;
    bool isLeft = false;
    bool isMid = true;

    // Update is called once per frame
    void Update()
    {
        /*float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }*/

        //Vector3 forward = new Vector3(0f, 0f, 1f).normalized;
        //controller.Move(Vector3.forward * speed * Time.deltaTime);

        transform.position += ((Vector3.forward) * speed * Time.deltaTime);

        Vector3 laneChange = new Vector3(5.5f, 0, 0);

        if (Input.GetKeyDown(KeyCode.D) && !isRight)
        {
            transform.position += laneChange;
            if (isMid)
            {
                isMid = false;
                isRight = true;
                animator.SetBool("isMid", false);
                animator.SetBool("isRight", true);
            }
            else
            {
                isMid = true;
                isLeft = false;
                animator.SetBool("isMid", true);
                animator.SetBool("isLeft", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && !isLeft)
        {
            transform.position -= laneChange;
            if (isMid)
            {
                isMid = false;
                isLeft = true;
                animator.SetBool("isMid", false);
                animator.SetBool("isLeft", true);
            }
            else
            {
                isMid = true;
                isRight = false;
                animator.SetBool("isMid", true);
                animator.SetBool("isRight", false);
            }
        }
    }
}
