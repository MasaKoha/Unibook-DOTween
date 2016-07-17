using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MoveX : MonoBehaviour
{
    private void Start()
    {
        DOTween.Init();
        DOTween.Sequence().Append(this.transform.DOMoveX(3, 1));
    }
}
