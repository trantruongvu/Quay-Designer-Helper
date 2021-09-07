using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public Transform questContent;
    public QuestScript questPrefab;

    List<QuestScript> quests;

    // Start is called before the first frame update
    void Start()
    {
        quests = new List<QuestScript>();
        quests.Add(new QuestScript { });
    }

}
