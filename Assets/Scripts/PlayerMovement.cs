using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    float horizontalMovement = 0f;
    float playerSpeed = 15f;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody_2D;
    Animator animator;
    Transform transform_;
    Vector3 forward;
    Vector3 backward;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody_2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform_ = GetComponent<Transform>();
        forward = new Vector3(0, 0, 0);
        backward = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        transform_.position += new Vector3(horizontalMovement, 0, 0);

        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));

        // if(horizontalMovement != 0)
        // {
        //     animator.SetBool("isFire", true);
        // }else{
        //     animator.SetBool("isFire", false);
        // }

        if(horizontalMovement > 0)
        {
            // spriteRenderer.flipX = false;
            transform_.eulerAngles = forward;
            
        }
        else if (horizontalMovement < 0){
            // spriteRenderer.flipX = true;
            transform_.eulerAngles = backward;

            
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(transform_.position.y < 1.0)
            {
                rigidbody_2D.AddForce(Vector3.up * 250);
            }
        }

        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isFire", true);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("isFire", false);
        }
    }
}
