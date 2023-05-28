using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject spaceShip;
    [SerializeField]
    Image healthBar;
    [SerializeField]
    float healthCount = 100;
    float startHealthCount;
    static float flag;
    [SerializeField]
    GameObject destroyer;
    [SerializeField]
    TMP_Text score;

    private void Start()
    {
        menu.SetActive(false);
        startHealthCount = healthCount;
        flag = 100;
        destroyer.SetActive(false);
    }


    private void Update()
    {
        healthCount = flag;
        if(healthCount <= 0)
        {
            menu.SetActive(true);
            destroyer.SetActive(true);
            spaceShip.SetActive(false);
        }


        if (RestatrLvl.Restarter)
        {
            score.text = "0";
            spaceShip.SetActive(true);
            menu.SetActive(false);
            destroyer.SetActive(false);
            healthCount = startHealthCount;
            healthBar.fillAmount = healthCount / 100;
            RestatrLvl.Restarter = false;
            flag = 100;
        }
    }

    public static float Flag
    { 
        get { return flag; }
        set { flag = value; } 
    }
 
}
