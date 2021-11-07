using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed = 1f; 
    Rigidbody2D myRigidbody;
    Transform myTransform;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    void flipEnemyFacing()
    {
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        flipEnemyFacing();

    }
}
