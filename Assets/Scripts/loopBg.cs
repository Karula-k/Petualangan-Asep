using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopBg : MonoBehaviour
{
    // Start is called before the first frame update
    /*private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
        DontDestroyOnLoad(this.gameObject);
        }
    }*/
    void Awake()
    {
        setup();
    }
    private void setup()
    {
        if (FindObjectsOfType(GetType()).Length>1) {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
