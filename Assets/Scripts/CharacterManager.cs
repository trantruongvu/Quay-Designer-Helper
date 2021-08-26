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
    List<ItemScript> _races;
    public List<Item> races;
    private Item race;
    List<ItemScript> _traits;
    public List<Item> traits;
    private Item trait;
    List<ItemScript> _clothes;
    public List<Item> clothes;
    private Item cloth;
    List<ItemScript> _tables;
    public List<Item> tables;
    private Item table;
    List<ItemScript> _walls;
    public List<Item> walls;
    private Item wall;
    List<ItemScript> _hobbies;
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
        _races = new List<ItemScript>();
        _traits = new List<ItemScript>();
        _clothes = new List<ItemScript>();
        _tables = new List<ItemScript>();
        _walls = new List<ItemScript>();
        _hobbies = new List<ItemScript>();

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

        if (race == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = race.Name; txtItemDescription.text = race.Description; }

        if (contentRace.childCount == 0)
            SpawnItems(races, contentRace);

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

        if (trait == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = trait.Name; txtItemDescription.text = trait.Description; }

        if (contentTrait.childCount == 0)
            SpawnItems(traits, contentTrait);

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

        if (cloth == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = cloth.Name; txtItemDescription.text = cloth.Description; }

        if (contentCloth.childCount == 0)
            SpawnItems(clothes, contentCloth);

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

        if (table == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = table.Name; txtItemDescription.text = table.Description; }

        if (contentTable.childCount == 0)
            SpawnItems(tables, contentTable);

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

        if (wall == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = wall.Name; txtItemDescription.text = wall.Description; }

        if (contentWall.childCount == 0)
            SpawnItems(walls, contentWall);

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

        if (hobby == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = hobby.Name; txtItemDescription.text = hobby.Description; }

        if (contentHobby.childCount == 0)
            SpawnItems(hobbies, contentHobby);

        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.RoundToInt(hobbies.Count / 3)), 0);

        // Prev -> Wall
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() => { DisplayChooseWall(true); DisplayChooseHobby(false); });

        // Next -> Character
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() => { if (hobby == null) return; DisplayChooseHobby(false); DisplayCharacter(true); });
    }

    /// <summary>
    /// Spawn Items
    /// </summary>
    /// <param name="items">Item list</param>
    /// <param name="_prefab">Item prefab</param>
    /// <param name="_parent">Item to spawn in</param>
    /// <param name="_item">Item holder</param>
    private void SpawnItems(List<Item> items, Transform parent)
    {
        if (parent.childCount > 0)
            return;

        foreach (Item item in items)
        {
            ItemScript newItem = Instantiate(itemPrefab, parent);
            newItem.image.sprite = item.Default;
            newItem.btnChoose.onClick.AddListener(() =>
            {
                txtItemName.text = item.Name;
                txtItemDescription.text = item.Description;

                if (parent == contentRace)
                {
                    race = item;
                    for (int i = 0; i < _races.Count; i++) { _races[i].image.sprite = races[i].Default; }
                }
                else if (parent == contentTrait)
                {
                    trait = item;
                    for (int i = 0; i < _traits.Count; i++) { _traits[i].image.sprite = traits[i].Default; }
                }
                else if (parent == contentWall)
                {
                    wall = item;
                    for (int i = 0; i < _walls.Count; i++) { _walls[i].image.sprite = walls[i].Default; }
                }
                else if (parent == contentTable)
                {
                    table = item;
                    for (int i = 0; i < _tables.Count; i++) { _tables[i].image.sprite = tables[i].Default; }
                }
                else if (parent == contentCloth)
                {
                    cloth = item;
                    for (int i = 0; i < _clothes.Count; i++) { _clothes[i].image.sprite = clothes[i].Default; }
                }
                else if (parent == contentHobby)
                {
                    hobby = item;
                    for (int i = 0; i < _hobbies.Count; i++) { _hobbies[i].image.sprite = hobbies[i].Default; }
                }

                newItem.image.sprite = item.Avatar;
            });

            if      (parent == contentRace) { _races.Add(newItem); }
            else if (parent == contentTrait) { _traits.Add(newItem); }
            else if (parent == contentWall) { _walls.Add(newItem); }
            else if (parent == contentTable) { _tables.Add(newItem); }
            else if (parent == contentCloth) { _clothes.Add(newItem); }
            else if (parent == contentHobby) { _hobbies.Add(newItem); }
        }
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
