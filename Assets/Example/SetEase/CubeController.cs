using UnityEngine;
using System.Collections;
using DG.Tweening;

/// <summary>
/// Cube を様々な方法で動かす
/// </summary>
public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    private Vector3 _endPosition = new Vector3(15, 0, 0);
    private Vector3 _initPosition = new Vector3(0, 0, 0);
    private float _moveTime = 1.0f;

    private void Start()
    {
        DOTween.Init();
    }

    private void Initialize()
    {
        _cube.transform.position = _initPosition;
    }

    // easing 参考資料 http://easings.net/ja
    public void Linear()
    {
        Initialize();
        DOTween.Sequence()
            .Append(_cube.transform.DOMove(_endPosition, _moveTime))
            .SetEase(Ease.Linear);
    }

    public void InSine()
    {
        Initialize();
        DOTween.Sequence()
            .Append(_cube.transform.DOMove(_endPosition, _moveTime))
            .SetEase(Ease.InSine);
    }

    public void OutSine()
    {
        Initialize();
        DOTween.Sequence()
            .Append(_cube.transform.DOMove(_endPosition, _moveTime))
            .SetEase(Ease.OutSine);
    }

    public void InBounce()
    {
        Initialize();
        DOTween.Sequence()
            .Append(_cube.transform.DOMove(_endPosition, _moveTime))
            .SetEase(Ease.InBounce);
    }

    public void OutBounce()
    {
        Initialize();
        DOTween.Sequence()
            .Append(_cube.transform.DOMove(_endPosition, _moveTime))
            .SetEase(Ease.InOutBounce);
    }
}
