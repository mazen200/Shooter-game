using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraingleEnemyBehavior : MonoBehaviour
{
    Vector2 dir;
    float rot;
    Transform player;
    bool canshoot = true;
    [SerializeField] float shootDelay;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        handelAming();
    }

    void handelAming()
    {
        dir = player.position - transform.position;
        rot = Mathf.Atan2(dir.y , dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void handleShooting()
    {
        
    }

    IEnumerator shootingDelay()
    {
        canshoot = false;
        yield return new WaitForSeconds(shootDelay);
        canshoot = true;
    }
}
