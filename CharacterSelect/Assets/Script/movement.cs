using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    bool isJumping = false;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    public float jumpHeight = 0f;
    float jump = 0f;
    public Image bar;


    private void Start()
    {
        bar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //variable pulls value from intrinsic horizontal speed within unity

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));  //tell the animator to change a variable value
        animator.SetFloat("jump", jump);

        if(Input.GetButtonDown("Jump"))  //changing power of jump as button is held down
        {
            isJumping = true;
            //animator.SetBool("jump", true);
            //jump = true;
        }
        if(isJumping)
        {
            jumpHeight += 0.05f;
            bar.fillAmount = jumpHeight / 3f;
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (jumpHeight < 1)
            {
                jump = 1f;
            }
            else if ((jumpHeight>=1) && (jumpHeight < 2))
            {
                jump = 2f;
            }
            else
            {
                jump = 3f;
            }

            isJumping = false;
            jumpHeight = 0f;
        }

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = 0f;
    }
}
