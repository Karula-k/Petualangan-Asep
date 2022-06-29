using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{   
    [SerializeField] private string scaneName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Boundary") {
            SceneManager.LoadScene(scaneName);
        }
    }
}
