using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleScript : MonoBehaviour
{
    Sequence seq;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        seq = DOTween.Sequence();
    }

    public void StartWobble()
    {
        if (seq.IsPlaying())
            return;
        
        seq = DOTween.Sequence();
        seq.Append(transform.DOScaleX(0.9f, 0.25f));
        seq.Join(transform.DOScaleY(0.95f, 0.25f));
        seq.Join(transform.DOMoveX(transform.position.x - 15f, 0.25f));
        seq.Append(transform.DOScaleX(1f, 0.25f));
        seq.Join(transform.DOScaleY(1f, 0.25f));
        seq.Join(transform.DOMoveX(transform.position.x, 0.25f));
        seq.Play();
    }
}
