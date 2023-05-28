using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    Rigidbody2D rb_Bullet;
    [SerializeField]
    bool isPlayerGan = true;

    private void Start()
    {
        int gunVector = 1;
        if (isPlayerGan == false)
            gunVector = -1;
        rb_Bullet.velocity = transform.up * speed * gunVector;
        Destroy(gameObject, 2);
    }
}
