using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D bc;
    [SerializeField] Transform transform;
    Animator animator;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 0f)
            animator.SetBool("isDead", true);         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (animator.GetBool("isDead") == false)
        {
            if (collision.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);
                transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y);
            }
        }
    }
}
