using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Animator animator;

    public Sprite disable;
    public Sprite enable;

    private Image image;
    private bool status;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        status = false;
    }

    public void ChangeSprite()
    {
        status = !status;

        if (status)
            image.sprite = enable;
        else
            image.sprite = disable;
    }

    public void PlayAnim(string animName)
    {
        animator.SetTrigger(animName);
    }
}
