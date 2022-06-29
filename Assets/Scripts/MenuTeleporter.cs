using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTeleporter : MonoBehaviour
{
    [SerializeField] private string scaneName;
    public void Teleport()
    {
        SceneManager.LoadScene(scaneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
