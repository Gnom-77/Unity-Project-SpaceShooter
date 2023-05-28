using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    [SerializeField]
    int enemy_hp = 1;
    [SerializeField]
    GameObject[] Bullet_Prefab;
    [SerializeField]
    float Tiem_Spawn = 0.5f;
    [SerializeField]
    GameObject[] GunPosition;
    [SerializeField]
    bool isHaveGun = false;
    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    AudioSource shoot_Sound;



    private void Start()
    {
        if (isHaveGun)
        {
            StartCoroutine(Enemy_Spawn());
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bull")
        {
            enemy_hp--;
            if (enemy_hp <= 0)
            {
                Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }


    IEnumerator Enemy_Spawn()
    {
        while (true)
        {
            shoot_Sound.Play();
            Instantiate(Bullet_Prefab[0], GunPosition[0].transform.position, GunPosition[0].transform.rotation);
            Instantiate(Bullet_Prefab[1], GunPosition[1].transform.position, GunPosition[1].transform.rotation);
            Instantiate(Bullet_Prefab[2], GunPosition[2].transform.position, GunPosition[2].transform.rotation);
            Instantiate(Bullet_Prefab[3], GunPosition[3].transform.position, GunPosition[3].transform.rotation);
            yield return new WaitForSeconds(Tiem_Spawn);
        }
    }

}
