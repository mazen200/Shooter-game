using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemeyBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 dir;
    Transform player;
    Rigidbody2D rb;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        findDirctionPlayer();
        setSpeed(dir.normalized * speed);
    }
    private void Update()
    {
        if(animator.GetBool("dead"))
            setSpeed(new Vector2(0.0f,0.0f));
    }
    void findDirctionPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dir = player.transform.position - transform.position;
    }
    void setSpeed(Vector2 speed)
    {
        rb.velocity = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            animator.SetBool("dead", true);
            StartCoroutine("remove");
        }
    }

    IEnumerator remove()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
