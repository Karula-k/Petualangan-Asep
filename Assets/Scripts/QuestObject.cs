using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int number;
    public int totalnumber;
    public int questNumber;
    public bool item;
    public QuestManager qm;
   // public GameObject puzzle;
    public Uifirenotif uifirenotif;
    // Start is called before the first frame update
    void Start()
    {
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        uifirenotif.Score = string.Format("{0}/{1}", number, totalnumber);
        if (item && number == totalnumber)
        {
            number = 0;
            EndQuest();
        }
    }
    public void StartsQuest()
    {

    }
    public void EndQuest()
    {
        qm.questComplete[questNumber] = true;
        gameObject.SetActive(false);
        //puzzle.SetActive(true);
    }
}
