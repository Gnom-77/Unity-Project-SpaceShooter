using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooting_Space_Ship : MonoBehaviour
{
    [SerializeField]
    Transform firePosition;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float timer = 10f;
    float timer_for_shoot;
    bool permission_to_shoot = true;
    [SerializeField]
    TMP_Text score;
    [SerializeField]
    Double point = 1f;
    [SerializeField]
    AudioSource shoot_sound;

    private void Start()
    {
        score.text = "0";
        timer_for_shoot = timer;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }

    }
    private void FixedUpdate()
    {
        timer_for_shoot -= Time.deltaTime;
        if (timer_for_shoot <= 0)
        {
            permission_to_shoot = true;
            timer_for_shoot = timer;
        }

        score.text = (Convert.ToDouble(score.text) + point).ToString();

        
    }
    void Shoot()
    {
        if (permission_to_shoot)
        {
            shoot_sound.Play();
            Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            permission_to_shoot = false;
        }
    }
}
