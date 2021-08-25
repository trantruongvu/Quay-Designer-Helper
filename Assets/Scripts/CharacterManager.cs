using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    public Image imgCharacter;
    public GameObject panelCreate;
    public GameObject panelChacter;
    public TextMeshProUGUI txtItemName;
    public TextMeshProUGUI txtItemDescription;

    // Panels
    public GameObject panelRace;
    public GameObject panelTrait;
    public GameObject panelCloth;
    public GameObject panelTable;
    public GameObject panelWall;
    public GameObject panelHobby;

    // Item Prefab
    public ItemScript itemPrefab;

    // Contents
    private Transform contentRace;
    private Transform contentTrait;
    private Transform contentCloth;
    private Transform contentTable;
    private Transform contentWall;
    private Transform contentHobby;

    // Seperate Line 
    public Transform lineBottom;

    // Items
    public List<Item> races;
    private Item race;
    public List<Item> traits;
    private Item trait;
    public List<Item> clothes;
    private Item cloth;
    public List<Item> tables;
    private Item table;
    public List<Item> walls;
    private Item wall;
    public List<Item> hobbies;
    private Item hobby;

    // Buttons
    public Button btnPrev;
    public Button btnNext;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        contentRace = panelRace.transform.GetChild(0);
        //contentTrait = panelTrait.transform.GetChild(0);
        //contentCloth = panelCloth.transform.GetChild(0);
        //contentTable = panelTable.transform.GetChild(0);
        //contentWall = panelWall.transform.GetChild(0);
        //contentHobby = panelHobby.transform.GetChild(0);

        DisplayChooseRace(true);
    }

    public void ChooseItem(Item _itemHolder, Item _item)
    {
        _itemHolder = _item;
    }


    // Item 1: Race
    public void DisplayChooseRace(bool status)
    {
        panelRace.SetActive(status);

        if (!status)
            return;

        foreach (Item item in races)
        {
            ItemScript newItem = Instantiate(itemPrefab, contentRace);
            newItem.image.sprite = item.Sprite;
            newItem.btnChoose.onClick.AddListener(() =>
            {
                txtItemName.text = item.name;
                txtItemDescription.text = item.Description;
                ChooseItem(race, item);
            });
        }

        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * (races.Count % 3)), 0);
        
        // 
        btnPrev.gameObject.SetActive(false);
        btnPrev.onClick.RemoveAllListeners();
        
        // Next -> Trait
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() =>
        {
            if (race == null) // Check đã chọn chưa
                return;
            DisplayChooseTrait(true);
            DisplayChooseRace(false);
        });
        
    }

    // Item 2: Trait
    private void DisplayChooseTrait(bool status)
    {
        panelTrait.SetActive(status);

        if (!status)
            return;

        foreach (Item item in traits)
        {
            ItemScript newItem = Instantiate(itemPrefab, contentTrait);
            newItem.image.sprite = item.Sprite;
            newItem.btnChoose.onClick.AddListener(() =>
            {
                txtItemName.text = item.name;
                txtItemDescription.text = item.Description;
                ChooseItem(trait, item);

                //DisplayChooseCloth(true);
                //DisplayChooseTrait(false);
            });
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * (races.Count % 3)), 0);
        
        // Prev -> Race
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() =>
        {

        });
        
        // Next -> Cloth
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() =>
        {

        });
        panelRace.SetActive(false);
        panelTrait.SetActive(status);
    }

    // Item 3: Clothes
    private void DisplayChooseCloth(bool status)
    {
        panelCloth.SetActive(status);

        if (!status)
            return;

        foreach (Item item in races)
        {
            ItemScript newItem = Instantiate(itemPrefab, contentCloth);
            newItem.image.sprite = item.Sprite;
            newItem.btnChoose.onClick.AddListener(() =>
            {
                txtItemName.text = item.name;
                txtItemDescription.text = item.Description;
                ChooseItem(cloth, item);

                //DisplayChooseTable(true);
                //DisplayChooseCloth(false);
            });
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * (races.Count % 3)), 0);
    }


    // Item 4: Tables
    private void DisplayChooseTable(bool status)
    {
        panelTable.SetActive(status);

        if (!status)
            return;

        foreach (Item item in races)
        {
            ItemScript newItem = Instantiate(itemPrefab, contentTable);
            newItem.image.sprite = item.Sprite;
            newItem.btnChoose.onClick.AddListener(() =>
            {
                txtItemName.text = item.name;
                txtItemDescription.text = item.Description;
                ChooseItem(table, item);

                //DisplayChooseWall(true);
                //DisplayChooseTable(false);
            });
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * (races.Count % 3)), 0);
    }

    // Item 5: Walls
    private void DisplayChooseWall(bool status)
    {
        foreach (Item item in walls)
        {
            ItemScript newItem = Instantiate(itemPrefab, contentWall);
            newItem.image.sprite = item.Sprite;
            newItem.btnChoose.onClick.AddListener(() =>
            {
                txtItemName.text = item.name;
                txtItemDescription.text = item.Description;
                ChooseItem(wall, item);

                //DisplayChooseHobby(true);
                //DisplayChooseWall(false);
            });
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * (races.Count % 3)), 0);
    }

    // Item 6: Hobbies
    private void DisplayChooseHobby(bool status)
    {
        foreach (Item item in hobbies)
        {
            ItemScript newItem = Instantiate(itemPrefab, contentHobby);
            newItem.image.sprite = item.Sprite;
            newItem.btnChoose.onClick.AddListener(() =>
            {
                txtItemName.text = item.name;
                txtItemDescription.text = item.Description;
                ChooseItem(hobby, item);

                //DisplayChooseHobby(true);
                //DisplayChooseWall(false);
            });
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * (races.Count % 3)), 0);
    }


    public void DisplayCharacter(bool status)
    {
        panelCreate.SetActive(false);
        GetCharacter();
        panelChacter.SetActive(status);
    }

    public void GetCharacter()
    {

    }

    public void ResetCharacter()
    {
        DisplayChooseRace(true);
    }
}
