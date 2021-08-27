using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ChooseCard()
    {
        if (CardSpawner.Instance.isChoosingCard)
            return;

        CardSpawner.Instance.isChoosingCard = true;

        // Kéo lá bài
        Sequence seq1 = DOTween.Sequence();
        seq1.Append(transform.DOMove(transform.position - (transform.up * 500), 1f));
        seq1.OnComplete(() =>
        {
            transform.SetSiblingIndex(transform.parent.childCount);

            // Phóng to lá bài
            Sequence seq2 = DOTween.Sequence();
            seq2.Append(transform.DOMove(new Vector2(Screen.width / 2, Screen.height / 2), 1f));
            seq2.Join(transform.DOScale(Vector3.one * 2, 1f));
            seq2.Join(transform.DORotate(Vector3.zero, 1f));
            seq2.OnComplete(() =>
            {
                // Lật lá bài
                Sequence seq3 = DOTween.Sequence();
                seq3.Append(transform.DORotate(new Vector3(0, 90, 0), 1f));
                seq3.OnComplete(() =>
                {
                    // đổi lá bài
                    Sprite randomSprite = CardSpawner.Instance.cardSprites[Random.Range(0, CardSpawner.Instance.cardSprites.Count)];
                    gameObject.GetComponent<Image>().sprite = randomSprite;

                    // Lật lá bài
                    Sequence seq4 = DOTween.Sequence();
                    seq4.Append(transform.DORotate(Vector3.zero, 1f));
                    seq4.OnComplete(() => { StartCoroutine(GameController.Instance.I_TurnOffFortune()); });
                    seq4.Play();
                });
                seq3.Play();
            });
            seq2.Play();
        });
        seq1.Play();
    }
}
