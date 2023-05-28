using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestatrLvl : MonoBehaviour
{
    [SerializeField]
    static bool restarter = true;

    public static void Restart()
    {
        restarter = true;
    }

    public static bool Restarter 
    { 
        get { return restarter; } 
        set { restarter = value; }
    }
}
