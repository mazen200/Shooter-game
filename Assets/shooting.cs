using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shooting : MonoBehaviour
{
    Camera cam;
    Vector2 mousePos;
    [SerializeField] Transform shoulder;
    // Start is called before the first frame update
    void Start()
    {
        cam= Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        AimHandler();
        AnimationHandler();
    }
    private void AimHandler()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)shoulder.position;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shoulder.transform.rotation= Quaternion.Euler(0,0,rotation);
    }
    private void AnimationHandler()
    {
        if (transform.position.x <= mousePos.x)
        {
            Flip(false);
        }
        else
        {
            Flip(true);
        }
    }
    private void Flip(bool flip)
    {
        if (flip)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }
}
