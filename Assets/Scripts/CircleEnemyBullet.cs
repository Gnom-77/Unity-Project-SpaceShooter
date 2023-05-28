using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyBullet : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    Rigidbody2D rb_Bullet;
    [SerializeField]
    bool isRight = true;

    private void Start()
    {
        int gunVector = 1;
        if (isRight == false)
            gunVector = -1;
        rb_Bullet.velocity = transform.right * speed * gunVector;
        Destroy(gameObject, 2);
    }
}
