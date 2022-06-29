using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItem : MonoBehaviour
{
    private QuestManager qm;
    public int number;
    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        qm = FindObjectOfType<QuestManager>();
        Debug.Log(qm.quests[number].number);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && first ) {
            if (!qm.questComplete[number])
            {
                qm.quests[number].gameObject.SetActive(true);
                qm.quests[number].number++;
                Debug.Log(qm.quests[number].number);
                first = false;
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
