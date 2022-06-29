using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleTrigger : MonoBehaviour
{
    private SliderManager puzzle;
    private QuestManager qm;
    private bool firstTriger =true;
    [SerializeField] int numberquest;
    // Start is called before the first frame update
    void Start()
    {
        puzzle = FindObjectOfType<SliderManager>();
        qm = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player"&&firstTriger)
        {
            if (qm.questComplete[numberquest])
            {
            puzzle.StarsPuzzle();
                firstTriger = false;
            }

        }
    }
}
