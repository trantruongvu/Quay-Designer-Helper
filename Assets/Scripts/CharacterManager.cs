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
    [Header("Panels")]
    public GameObject panelRace;
    public GameObject panelTrait;
    public GameObject panelCloth;
    public GameObject panelTable;
    public GameObject panelWall;
    public GameObject panelHobby;

    // Item Prefab
    [Header("Item Prefab")]
    public ItemScript itemPrefab;

    // Contents
    [Header("Contents")]
    private Transform contentRace;
    private Transform contentTrait;
    private Transform contentCloth;
    private Transform contentHobby;
    private Transform contentTable;
    private Transform contentWall;

    // Wardrobe
    [Header("Wardrobe")]
    public Transform wcontentRace;
    List<ItemScript> wcontentRaces;
    public Transform wcontentTrait;
    List<ItemScript> wcontentTraits;
    public Transform wcontentHobby;
    List<ItemScript> wcontentHobbies;
    public Transform wcontentCloth;
    List<ItemScript> wcontentClothes;
    public Transform wcontentWall;
    List<ItemScript> wcontentWalls;
    public Transform wcontentTable;
    List<ItemScript> wcontentTables;

    public Transform wvaluewvalueControl;
    public Transform wvalueExecution;
    public Transform wvalueThinking;
    public Transform wvalueResilient;

    // Seperate Line 
    public Transform lineBottom;

    // Images
    [Header("Avatar Images")]
    public Image imgRace;
    public Image imgCloth;
    public Image imgHobby;
    public Image imgTable;
    public Image imgWall;

    // Items
    [Header("List items")]
    List<ItemScript> _races;
    public List<Item> races;
    [HideInInspector] public Item race;
    List<ItemScript> _traits;
    public List<Item> traits;
    [HideInInspector] public Item trait;
    List<ItemScript> _clothes;
    public List<Item> clothes;
    [HideInInspector] public Item cloth;
    List<ItemScript> _hobbies;
    public List<Item> hobbies;
    [HideInInspector] public Item hobby;
    List<ItemScript> _tables;
    public List<Item> tables;
    [HideInInspector] public Item table;
    List<ItemScript> _walls;
    public List<Item> walls;
    [HideInInspector] public Item wall;

    // Values
    [HideInInspector] public int valueControl;
    [HideInInspector] public int valueExecution;
    [HideInInspector] public int valueThinking;
    [HideInInspector] public int valueResilient;


    // Buttons
    [Header("UI buttons")]
    public Button btnPrev;
    public Button btnNext;
    public Button btnChoose;

    [Header("Img Info")]
    public GameObject imgInfo;
    public Text txtName;
    public Text txtDescription;

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

        wcontentRaces = new List<ItemScript>();
        wcontentTraits = new List<ItemScript>();
        wcontentClothes = new List<ItemScript>();
        wcontentTables = new List<ItemScript>();
        wcontentWalls = new List<ItemScript>();
        wcontentHobbies = new List<ItemScript>();

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

        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.CeilToInt(races.Count / 3)), 0);

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

        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.CeilToInt(traits.Count / 3)), 0);

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

        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.CeilToInt(clothes.Count / 3)), 0);

        // Prev -> Cloth
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() =>
        {
            DisplayChooseTrait(true);
            DisplayChooseCloth(false);
        });

        // Next -> Table
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() =>
        {
            if (cloth == null)
                return;
            DisplayChooseHobby(true);
            DisplayChooseCloth(false);
        });
    }

    // Item 4: HOBBY
    private void DisplayChooseHobby(bool status)
    {
        panelHobby.SetActive(status);

        if (!status)
            return;

        if (hobby == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = hobby.Name; txtItemDescription.text = hobby.Description; }

        if (contentHobby.childCount == 0)
            SpawnItems(hobbies, contentHobby);

        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.CeilToInt(hobbies.Count / 3)), 0);

        // Prev -> Wall
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() =>
        {
            DisplayChooseCloth(true);
            DisplayChooseHobby(false);
        });

        // Next -> Character
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() =>
        {
            if (hobby == null)
                return;
            DisplayChooseHobby(false);
            DisplayChooseTable(true);
        });
    }


    // Item 5: TABLE
    private void DisplayChooseTable(bool status)
    {
        panelTable.SetActive(status);

        if (!status)
            return;

        if (table == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = table.Name; txtItemDescription.text = table.Description; }

        if (contentTable.childCount == 0)
            SpawnItems(tables, contentTable);

        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.CeilToInt(tables.Count / 3f)), 0);

        // Prev -> Cloth
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() =>
        {
            DisplayChooseHobby(true);
            DisplayChooseTable(false);
        });

        // Next -> Wall
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() =>
        {
            if (table == null) return;
            DisplayChooseWall(true);
            DisplayChooseTable(false);
        });
    }

    // Item 6: WALL
    private void DisplayChooseWall(bool status)
    {
        panelWall.SetActive(status);

        if (!status)
            return;

        if (wall == null) { txtItemName.text = ""; txtItemDescription.text = ""; }
        else { txtItemName.text = wall.Name; txtItemDescription.text = wall.Description; }

        if (contentWall.childCount == 0)
            SpawnItems(walls, contentWall);

        lineBottom.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -(205 + 270 + 300 * Mathf.CeilToInt(walls.Count / 3)), 0);

        // Prev -> Table
        btnPrev.onClick.RemoveAllListeners();
        btnPrev.onClick.AddListener(() =>
        {
            DisplayChooseTable(true);
            DisplayChooseWall(false);
        });

        // Next -> Hobby
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() =>
        {
            if (wall == null)
                return;
            DisplayCharacter(true);
            DisplayChooseWall(false);
        });
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

            if (parent == contentRace) { _races.Add(newItem); }
            else if (parent == contentTrait) { _traits.Add(newItem); }
            else if (parent == contentWall) { _walls.Add(newItem); }
            else if (parent == contentTable) { _tables.Add(newItem); }
            else if (parent == contentCloth) { _clothes.Add(newItem); }
            else if (parent == contentHobby) { _hobbies.Add(newItem); }
        }
    }

    private void SpawnItemsWardrobe(List<Item> items, Transform parent)
    {
        if (parent.childCount > 0)
            return;

        foreach (Item item in items)
        {
            ItemScript newItem = Instantiate(itemPrefab, parent);

            if (item.Name.Equals(race.Name) || item.Name.Equals(cloth.Name) || item.Name.Equals(wall.Name) || item.Name.Equals(table.Name) || item.Name.Equals(trait.Name) || item.Name.Equals(hobby.Name))
                newItem.image.sprite = item.Avatar;
            else
                newItem.image.sprite = item.Default;

            newItem.btnChoose.onClick.AddListener(() =>
            {
                btnChoose.onClick.RemoveAllListeners();

                imgInfo.SetActive(true);
                txtName.text = item.Name;
                txtDescription.text = item.Description;

                if (parent == wcontentRace)
                {
                    btnChoose.onClick.AddListener(() =>
                    {
                        race = item;
                        for (int i = 0; i < wcontentRaces.Count; i++) { wcontentRaces[i].image.sprite = races[i].Default; }
                        newItem.image.sprite = item.Avatar;
                        imgInfo.SetActive(false);
                        GetCharacter();
                    });
                }
                else if (parent == wcontentTrait)
                {
                    btnChoose.onClick.AddListener(() =>
                    {
                        trait = item;
                        for (int i = 0; i < wcontentTraits.Count; i++) { wcontentTraits[i].image.sprite = traits[i].Default; }
                        newItem.image.sprite = item.Avatar;
                        imgInfo.SetActive(false);
                        GetCharacter();
                    });
                }
                else if (parent == wcontentWall)
                {
                    btnChoose.onClick.AddListener(() =>
                    {
                        wall = item;
                        for (int i = 0; i < wcontentWalls.Count; i++) { wcontentWalls[i].image.sprite = walls[i].Default; }
                        newItem.image.sprite = item.Avatar;
                        imgInfo.SetActive(false);
                        GetCharacter();
                    });
                }
                else if (parent == wcontentTable)
                {
                    btnChoose.onClick.AddListener(() =>
                    {
                        table = item;
                        for (int i = 0; i < wcontentTables.Count; i++) { wcontentTables[i].image.sprite = tables[i].Default; }
                        newItem.image.sprite = item.Avatar;
                        imgInfo.SetActive(false);
                        GetCharacter();
                    });
                }
                else if (parent == wcontentCloth)
                {
                    btnChoose.onClick.AddListener(() =>
                    {
                        cloth = item;
                        for (int i = 0; i < wcontentClothes.Count; i++) { wcontentClothes[i].image.sprite = clothes[i].Default; }
                        newItem.image.sprite = item.Avatar;
                        imgInfo.SetActive(false);
                        GetCharacter();
                    });
                }
                else if (parent == wcontentHobby)
                {
                    btnChoose.onClick.AddListener(() =>
                    {
                        hobby = item;
                        for (int i = 0; i < wcontentHobbies.Count; i++) { wcontentHobbies[i].image.sprite = hobbies[i].Default; }
                        newItem.image.sprite = item.Avatar;
                        imgInfo.SetActive(false);
                        GetCharacter();
                    });
                }
            });

            if (parent == wcontentRace) { wcontentRaces.Add(newItem); }
            else if (parent == wcontentTrait) { wcontentTraits.Add(newItem); }
            else if (parent == wcontentWall) { wcontentWalls.Add(newItem); }
            else if (parent == wcontentTable) { wcontentTables.Add(newItem); }
            else if (parent == wcontentCloth) { wcontentClothes.Add(newItem); }
            else if (parent == wcontentHobby) { wcontentHobbies.Add(newItem); }
        }
    }

    public void DisplayCharacter(bool status)
    {
        panelCreate.SetActive(false);
        GetCharacter();
        panelChacter.SetActive(status);

        // Wardrobe
        SpawnItemsWardrobe(races, wcontentRace);
        SpawnItemsWardrobe(traits, wcontentTrait);
        SpawnItemsWardrobe(clothes, wcontentCloth);
        SpawnItemsWardrobe(hobbies, wcontentHobby);
        SpawnItemsWardrobe(tables, wcontentTable);
        SpawnItemsWardrobe(walls, wcontentWall);
    }

    public void GetCharacter()
    {
        imgRace.sprite = race.Sprite;
        imgCloth.sprite = cloth.Sprite;
        imgHobby.sprite = hobby.Sprite;
        imgTable.sprite = table.Sprite;
        imgWall.sprite = wall.Sprite;

        valueControl = race.ValueControl + cloth.ValueControl + hobby.ValueControl + table.ValueControl + wall.ValueControl;
        valueExecution = race.ValueExecution + cloth.ValueExecution + hobby.ValueExecution + table.ValueExecution + wall.ValueExecution;
        valueThinking = race.ValueThinking + cloth.ValueThinking + hobby.ValueThinking + table.ValueThinking + wall.ValueThinking;
        valueResilient = race.ValueResilient + cloth.ValueResilient + hobby.ValueResilient + table.ValueResilient + wall.ValueResilient;

        wvaluewvalueControl.localScale = new Vector3(Mathf.Clamp(valueControl / 20f, 0f, 1f), 1, 1);
        wvalueExecution.localScale = new Vector3(Mathf.Clamp(valueExecution / 20f, 0f, 1f), 1, 1);
        wvalueThinking.localScale = new Vector3(Mathf.Clamp(valueThinking / 20f, 0f, 1f), 1, 1);
        wvalueResilient.localScale = new Vector3(Mathf.Clamp(valueResilient / 20f, 0f, 1f), 1, 1);
    }

    public void ResetCharacter()
    {
        panelCreate.SetActive(true);
        DisplayChooseRace(true);
    }
}
