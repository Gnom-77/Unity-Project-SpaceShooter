using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    public void paused()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void extend()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
}
