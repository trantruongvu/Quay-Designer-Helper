using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickieButtons : MonoBehaviour
{
    public GameObject panelProfile;
    public GameObject panelWardrobe;
    public GameObject panelQuest1;
    public GameObject panelQuest2;
    public GameObject panelQuest3;
    public GameObject panelGolem;
    public GameObject panelChallenge;

    public void DisplayProfile(bool status)
    {
        panelProfile.SetActive(status);
    }
    
    public void DisplayWardrobe (bool status)
    {
        panelWardrobe.SetActive(status);
    }
    public void DisplayQuest1(bool status)
    {
        panelQuest1.SetActive(status);
    }
    public void DisplayQuest2(bool status)
    {
        panelQuest2.SetActive(status);
    }
    public void DisplayQuest3(bool status)
    {
        panelQuest3.SetActive(status);
    }
    public void DisplayGolem(bool status)
    {
        panelGolem.SetActive(status);
    }
    public void DisplayChallenge(bool status)
    {
        panelChallenge.SetActive(status);
    }
}
