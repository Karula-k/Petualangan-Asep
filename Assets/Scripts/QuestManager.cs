using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] quests;
    public bool[] questComplete;
    // Start is called before the first frame update
    void Start()
    {
        questComplete = new bool[quests.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
