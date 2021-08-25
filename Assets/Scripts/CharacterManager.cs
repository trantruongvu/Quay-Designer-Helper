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
    public TextMeshProUGUI txtCharacterInfo;

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
        contentTrait = panelTrait.transform.GetChild(0);
        contentCloth = panelCloth.transform.GetChild(0);
        contentTable = panelTable.transform.GetChild(0);
        contentWall = panelWall.transform.GetChild(0);
        contentHobby = panelHobby.transform.GetChild(0);

        DisplayChooseRace(true);
    }

    // Item 1: RACE
    public void DisplayChooseRace(bool status)
    {
        panelRace.SetActive(status);

        if (!status)
            return;

        txtItemName.text = "";
        txtItemDescription.text = "";

        if (contentRace.childCount == 0)
        {
            foreach (Item item in races)
            {
                ItemScript newItem = Instantiate(itemPrefab, contentRace);
                newItem.image.sprite = item.Avatar;
                newItem.btnChoose.onClick.AddListener(() =>
                {
                    txtItemName.text = item.Name;
                    txtItemDescription.text = item.Description;
                    race = item;
                });
            }
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.RoundToInt(races.Count / 3)), 0);

        // Prev -> X
        btnPrev.gameObject.SetActive(false);
        btnPrev.onClick.RemoveAllListeners();

        // Next -> Trait
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() => { if (race == null) return; btnPrev.gameObject.SetActive(true); DisplayChooseTrait(true); DisplayChooseRace(false); });

    }

    // Item 2: TRAIT
    private void DisplayChooseTrait(bool status)
    {
        panelTrait.SetActive(status);

        if (!status)
            return;

        txtItemName.text = "";
        txtItemDescription.text = "";

        if (contentTrait.childCount == 0)
        {
            foreach (Item item in traits)
            {
                ItemScript newItem = Instantiate(itemPrefab, contentTrait);
                newItem.image.sprite = item.Avatar;
                newItem.btnChoose.onClick.AddListener(() =>
                {
                    txtItemName.text = item.Name;
                    txtItemDescription.text = item.Description;
                    trait = item;
                });
            }
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.RoundToInt(traits.Count / 3)), 0);

        // Prev -> Race
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() => { DisplayChooseRace(true); DisplayChooseTrait(false); });

        // Next -> Cloth
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() => { if (trait == null) return; DisplayChooseCloth(true); DisplayChooseTrait(false); });
    }

    // Item 3: CLOTH
    private void DisplayChooseCloth(bool status)
    {
        panelCloth.SetActive(status);

        if (!status)
            return;

        txtItemName.text = "";
        txtItemDescription.text = "";

        if (contentCloth.childCount == 0)
        {
            foreach (Item item in clothes)
            {
                ItemScript newItem = Instantiate(itemPrefab, contentCloth);
                newItem.image.sprite = item.Avatar;
                newItem.btnChoose.onClick.AddListener(() =>
                {
                    txtItemName.text = item.Name;
                    txtItemDescription.text = item.Description;
                    cloth = item;
                });
            }
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.RoundToInt(clothes.Count / 3)), 0);

        // Prev -> Cloth
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() => { DisplayChooseTrait(true); DisplayChooseCloth(false); });

        // Next -> Table
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() => { if (cloth == null) return; DisplayChooseTable(true); DisplayChooseCloth(false); });
    }


    // Item 4: TABLE
    private void DisplayChooseTable(bool status)
    {
        panelTable.SetActive(status);

        if (!status)
            return;

        txtItemName.text = "";
        txtItemDescription.text = "";

        if (contentTable.childCount == 0)
        {
            foreach (Item item in tables)
            {
                ItemScript newItem = Instantiate(itemPrefab, contentTable);
                newItem.image.sprite = item.Avatar;
                newItem.btnChoose.onClick.AddListener(() =>
                {
                    txtItemName.text = item.Name;
                    txtItemDescription.text = item.Description;
                    table = item;
                });
            }
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.RoundToInt(tables.Count / 3)), 0);

        // Prev -> Cloth
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() => { DisplayChooseCloth(true); DisplayChooseTable(false); });

        // Next -> Wall
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() => { if (table == null) return; DisplayChooseWall(true); DisplayChooseTable(false); });
    }

    // Item 5: WALL
    private void DisplayChooseWall(bool status)
    {
        panelWall.SetActive(status);

        if (!status)
            return;

        txtItemName.text = "";
        txtItemDescription.text = "";

        if (contentWall.childCount == 0)
        {
            foreach (Item item in walls)
            {
                ItemScript newItem = Instantiate(itemPrefab, contentWall);
                newItem.image.sprite = item.Avatar;
                newItem.btnChoose.onClick.AddListener(() =>
                {
                    txtItemName.text = item.Name;
                    txtItemDescription.text = item.Description;
                    wall = item;
                });
            }
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.RoundToInt(walls.Count / 3)), 0);

        // Prev -> Table
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() => { DisplayChooseTable(true); DisplayChooseWall(false); });

        // Next -> Hobby
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() => { if (wall == null) return; DisplayChooseHobby(true); DisplayChooseWall(false); });
    }

    // Item 6: HOBBY
    private void DisplayChooseHobby(bool status)
    {
        panelHobby.SetActive(status);

        if (!status)
            return;

        txtItemName.text = "";
        txtItemDescription.text = "";

        if (contentHobby.childCount == 0)
        {
            foreach (Item item in hobbies)
            {
                ItemScript newItem = Instantiate(itemPrefab, contentHobby);
                newItem.image.sprite = item.Avatar;
                newItem.btnChoose.onClick.AddListener(() =>
                {
                    txtItemName.text = item.Name;
                    txtItemDescription.text = item.Description;
                    hobby = item;
                });
            }
        }
        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.RoundToInt(hobbies.Count / 3)), 0);

        // Prev -> Wall
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() => { DisplayChooseWall(true); DisplayChooseHobby(false); });

        // Next -> Character
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() => { if (hobby == null) return; DisplayChooseHobby(false); DisplayCharacter(true); });
    }


    public void DisplayCharacter(bool status)
    {
        panelCreate.SetActive(false);
        GetCharacter();
        panelChacter.SetActive(status);
    }

    public void GetCharacter()
    {
        txtCharacterInfo.text = "Race: " + race.Name;
        txtCharacterInfo.text += "\nTrait: " + trait.Name;
        txtCharacterInfo.text += "\nCloth: " + cloth.Name;
        txtCharacterInfo.text += "\nTable: " + table.Name;
        txtCharacterInfo.text += "\nWall: " + wall.Name;
        txtCharacterInfo.text += "\nHobby: " + hobby.Name;
    }

    public void ResetCharacter()
    {
        panelCreate.SetActive(true);
        DisplayChooseRace(true);
    }
}
