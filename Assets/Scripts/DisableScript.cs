using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour
{
    public GameObject objectToDisable;
    public void _Disable()
    {
        if (objectToDisable != null)
            objectToDisable.SetActive(false);
        else
            gameObject.SetActive(false);
    }
}
