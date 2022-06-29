using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public string scaneName;
    private QuestManager qm;
    [SerializeField] private int questNumber;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && qm.questComplete[questNumber])
        {
            SceneManager.LoadScene(scaneName);
        }
    }
    private void Start()
    {
        qm = FindObjectOfType<QuestManager>();
    }
}
