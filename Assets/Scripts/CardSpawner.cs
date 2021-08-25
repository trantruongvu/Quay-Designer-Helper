using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    public static CardSpawner Instance;

    public Transform cardsSpinner;
    public Transform cardsHolder;
    public Transform cardPlacement;
    public Text txtDebug;

    public List<Sprite> cardSprites;
    private float angleMin;
    private float angleSpawn;
    private bool isSpreading = false;

    public Transform cardsParent;
    public Card cardPrefab;
    private List<Card> cards;

    private Animator cardAnimator;
    public bool isChoosingCard = false;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cardAnimator = gameObject.GetComponent<Animator>();

        if (cardSprites.Count == 0)
            angleMin = 180f * 2;
        else if (cardSprites.Count == 1)
            angleMin = 180f / 2;
        else
            angleMin = 180f / cardSprites.Count;

        angleSpawn = angleMin;

        //Debug.Log("angleSpawn : " + angleSpawn);
    }

    public void DisplayCards()
    {
        cardAnimator.SetTrigger("SpreadCard");
    }

    public void RemoveCards()
    {
        foreach (Card card in cards)
            Destroy(card);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpreading)
        {
            float angle = cardsSpinner.localEulerAngles.z;
            //txtDebug.text = Mathf.RoundToInt(angle).ToString();

            if (angle > angleSpawn)
            {
                //Debug.Log("angle : " + angle);

                Card newCard = Instantiate(cardPrefab, cardsParent);
                newCard.transform.position = cardPlacement.position;
                newCard.transform.rotation = cardPlacement.rotation;

                cards.Add(newCard);
                angleSpawn += angleMin;

                //Debug.Log("angleSpawn : " + angleSpawn);

                if (angleSpawn >= 180)
                    cardPlacement.gameObject.SetActive(false);
            }
        }
    }

    public void StartSpreading()
    {
        cards = new List<Card>();
        isSpreading = true;
    }

    public void StopSpreading()
    {
        isSpreading = false;
    }
}
