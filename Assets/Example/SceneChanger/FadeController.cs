using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class FadeController : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;

    private void Start()
    {
        DOTween.Init();
        DOTween.Sequence().Append(_fadeImage.DOColor(new Color(0, 0, 0, 0), 1));
    }
}
