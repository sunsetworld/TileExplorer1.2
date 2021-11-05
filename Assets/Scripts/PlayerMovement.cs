using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);

    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool PlayerHasHorizonalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", PlayerHasHorizonalSpeed);
    }

    void FlipSprite()
    {
        bool PlayerHasHorizonalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (PlayerHasHorizonalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}
