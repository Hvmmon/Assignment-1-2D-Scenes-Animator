using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyController : MonoBehaviour {
    public float moveSpeed = 3f;
    public float jumpSpeed = 10f;
    public Vector2 direction;
    public Rigidbody2D rb;
    public Animator animator;

    private Transform groundChecker;


    private bool needFlip = true;
    bool jump = false;
    // Start is called before the first frame update
    /* void Start() {
        rb = GetComponent<Rigidbody2D>();
        groundChecker = transform.GetChild(0);
    } */

    // Update is called once per frame
    void Update() {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.AddForce(Vector2.right * direction.x * moveSpeed);
       

        // animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("horizontal", Mathf.Abs(direction.x * moveSpeed));

        if ((direction.x > 0 && !needFlip) || (direction.x < 0 && needFlip)) {
            Flip();
        }

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            Attack();
        }

    }

    void Attack() {
        animator.SetTrigger("AttackTriggered");
    }

    void Jump() {
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        animator.SetTrigger("JumpTriggered");
    }


    void Flip() {
        needFlip = !needFlip;
        transform.rotation = Quaternion.Euler(0, needFlip ? 0 : 180, 0);
    }
}
