using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

/// <summary>
/// 数字を一定値表示する(表示する際はアニメーションっぽく)
/// </summary>
public class PrintNum : MonoBehaviour
{
    [SerializeField] private Text _numText;
    [SerializeField] private Button _button;
    private int _num;

    public int Num
    {
        get
        {
            return _num;
        }
        set
        {
            // Num に数字を入れると Text にも反映してくれるようにする
            _num = value;
            _numText.text = _num.ToString();
        }
    }

    public void OnClick()
    {
        // ただの初期化
        Num = 0;
        DOTween.To(() => Num, n => Num = n, 1000, 1)
        // いい感じに動かす
            .SetEase(Ease.OutCubic)
        // ボタンを押したら、1000 になるまで押せないようにする
            .OnPlay(() => ButtonActive(false))
        // 1000になったらボタンを押せるようにする
            .OnComplete(() => ButtonActive(true));
    }

    /// <summary>
    /// ボタンをアクティブ、非アクティブする
    /// </summary>
    private void ButtonActive(bool b)
    {
        _button.interactable = b;
    }
}
