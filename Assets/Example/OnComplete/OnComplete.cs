using UnityEngine;
using System.Collections;
using DG.Tweening;

public class OnComplete : MonoBehaviour
{
    [SerializeField] private GameObject _finishTextObj;

    private void Start()
    {
        DOTween.Init();
        DOTween.Sequence()
            .Append(this.transform.DOMove(new Vector3(5, 0, 0), 1))
            .OnComplete(ActiveText);
    }

    private void ActiveText()
    {
        _finishTextObj.SetActive(true);
    }
}
