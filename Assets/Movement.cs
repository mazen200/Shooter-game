using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask ground;
    Transform transform;

    Rigidbody2D rb;
    BoxCollider2D col;
    Animator anim;
    float acc = 0.01f;
    float gravity = 0.1f;
    Camera cam;
    void Start()
    {
        transform = GetComponent<Transform>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MovementHandler();
        JumpHandler();
        AnimationHandler();
    }
    private void MovementHandler()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal*speed * acc ,rb.velocity.y);
        if (horizontal!=0.0f)
        {
            if (acc < 2f)
                acc += 0.01f;
        }
        else
        {
            acc = 0.0f;
        }
        
    }
    private void JumpHandler()
    {
        if (Input.GetKeyDown(KeyCode.W)&& isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (!isGrounded())
        {
            rb.velocity = new Vector2( rb.velocity.x,rb.velocity.y-gravity);
        }
    }
    bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }
    private void AnimationHandler()
    {
        anim.SetBool("run", rb.velocity.x != 0);
        anim.SetBool("inAir", !isGrounded());
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x > transform.position.x)
            anim.SetBool("backward", rb.velocity.x < 0f);
        else
            anim.SetBool("backward", rb.velocity.x > 0f);
        
    }
}
