using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Hero : MonoBehaviour
{
    Vector2 mousePositin;
    [SerializeField]
    private float moveSpeed = 0.1f;
    Rigidbody2D rb_SpaceShip;
    Vector2 positin  = new Vector2(0f, 0f);
    [SerializeField]
    Image healthBar;
    [SerializeField]
    float healthCount = 100;
    float startHealthCount;


    private void Start()
    {
        rb_SpaceShip = GetComponent<Rigidbody2D>();
        startHealthCount = healthCount;
    }

    private void Update()
    {
        mousePositin = Input.mousePosition;
        mousePositin = Camera.main.ScreenToWorldPoint(mousePositin);
        positin = Vector2.Lerp(transform.position, mousePositin, moveSpeed);
    }

    private void FixedUpdate()
    {
        rb_SpaceShip.MovePosition(positin);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy_Bullet")
        {
            TakeDamage(20);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(float damage)
    {
        healthCount -= damage;
        healthBar.fillAmount = healthCount / 100;
        if (healthCount <= 0)
        {
            HealthManager.Flag = healthCount;
        }
        if (healthCount <= 0) 
        {
            healthCount = startHealthCount;
        }
    }

    private void Heal(float healing)
    {
        healthCount += healing;
        healthCount = Mathf.Clamp(healthCount, 0, 100);
        healthBar.fillAmount = healthCount / 100;
    }


}
