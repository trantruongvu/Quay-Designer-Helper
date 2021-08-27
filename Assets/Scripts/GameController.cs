using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject canvasProfile;
    public GameObject canvasRequest;
    public GameObject canvasInventory;
    public GameObject canvasFortune;

    public GameObject btnTurnOffFortune;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (CharacterManager.Instance.imgCharacter.sprite == null)
            CharacterManager.Instance.DisplayChooseRace(true);
        else
            CharacterManager.Instance.DisplayCharacter(true);
    }


    public void DisplayProfile(bool status)
    {
        canvasProfile.SetActive(status);
    }


    public void DisplayRequest(bool status)
    {
        canvasRequest.SetActive(status);
    }


    public void DisplayInventory(bool status)
    {
        canvasInventory.SetActive(status);
    }


    public void DisplayFortune(bool status)
    {
        canvasFortune.SetActive(status);
    }

    public IEnumerator I_TurnOffFortune()
    {
        yield return new WaitForSeconds(3f);
        btnTurnOffFortune.SetActive(true);
    }

    public void TurnOffFortune()
    {
        canvasFortune.SetActive(false);
        btnTurnOffFortune.SetActive(false);
    }
}
