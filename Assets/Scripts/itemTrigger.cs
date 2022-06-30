using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemTrigger : MonoBehaviour
{
    public int numberQuest;
    private QuestManager qm;
    public bool startsQuest;
    public bool endQuests;
    // Start is called before the first frame update
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }*/
    void Start()
    {
        qm = FindObjectOfType<QuestManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (!qm.questComplete[numberQuest])
            {
                if(startsQuest && !qm.quests[numberQuest].gameObject.activeSelf)
                {
                    qm.quests[numberQuest].gameObject.SetActive(true);
                    qm.quests[numberQuest].StartsQuest();
                }
                if(endQuests && qm.quests[numberQuest].gameObject.activeSelf)
                {
                    qm.quests[numberQuest].EndQuest();
                }
                Destroy(gameObject);
            }
        }
    }

}
