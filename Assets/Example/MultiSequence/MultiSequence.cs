using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

/// <summary>
/// Sequence を複数使用した UI アニメーション
/// </summary>
public class MultiSequence : MonoBehaviour
{
    /// <summary>
    /// バーの集合
    /// </summary>
    [SerializeField] private Image[] _bars;

    private Vector3[] _barsInitScale;

    private Color[] _barsInitColor;

    /// <summary>
    /// 画面下から現れる画像
    /// </summary>
    [SerializeField] private Image _underImage;

    private Vector3 _underImageInitAnchorPosition;

    /// <summary>
    /// リロードボタン
    /// </summary>
    [SerializeField] private Button _reloadButton;

    // スクリプトの初期化
    private void Start()
    {
        DOTween.Init();
        // リロードボタンが押されたときの処理をこのスクリプトで検知するように設定
        _reloadButton.onClick.AddListener(OnReload);

        // それぞれの bar や _underImage の初期位置と初期カラーを取っておく
        _barsInitScale = new Vector3[_bars.Length];
        _barsInitColor = new Color[_bars.Length];

        for (int i = 0; i < _bars.Length; i++)
        {
            _barsInitScale[i] = _bars[i].rectTransform.localScale;
            _barsInitColor[i] = _bars[i].color;
        }

        _underImageInitAnchorPosition = _underImage.rectTransform.anchoredPosition;
        OnReload();
    }

    // UI の初期化。
    private void UIInitialize()
    {
        for (int i = 0; i < _bars.Length; i++)
        {
            _bars[i].rectTransform.localScale = _barsInitScale[i];
            _bars[i].color = _barsInitColor[i];
        }
        _underImage.rectTransform.anchoredPosition = _underImageInitAnchorPosition;
    }

    /// <summary>
    /// リロードボタンが押された時の処理
    /// </summary>
    public void OnReload()
    {
        // リロードボタンを一度押したら押せないようにする(二重で反応させるとバグる)
        ReloadButtonInteractable(false);
        UIInitialize();
        // bar0 のアニメーションの登録
        Sequence bar0Animation = DOTween.Sequence()
            .Append(_bars[0].rectTransform.DOScaleX(1, 0.5f));
        // bar1 のアニメーションの登録
        Sequence bar1Animation = DOTween.Sequence()
            .Append(_bars[1].rectTransform.DOScaleX(1, 1.0f));
        // bar2 のアニメーションの登録
        Sequence bar2Animation = DOTween.Sequence()
            .Append(_bars[2].rectTransform.DOScaleX(1, 1.5f))
            .Join(_bars[2].DOColor(new Color(0, 1, 0, 1), 1.5f)
                .SetEase(Ease.InCubic));
        // underImage のアニメーションの登録
        Sequence underImageAnimation = DOTween.Sequence()
            .Append(_underImage.rectTransform.DOAnchorPosY(50, 1.0f, true));

        // 実際にアニメーションを走らせる部分
        DOTween.Sequence()
        // bar0,bar1,bar2 のアニメーションを同時に再生させる
            .Append(bar0Animation)
            .Join(bar1Animation)
            .Join(bar2Animation)
        // bar0,bar1,bar2のアニメーションが全て終了した後に underImage をアニメーション再生させる
            .Append(underImageAnimation)
        // アニメーションが終わったらリロードボタンを押せるようにする
            .OnComplete(() => ReloadButtonInteractable(true));
    }

    /// <summary>
    /// リロードボタンの有効化・無効化
    /// </summary>
    private void ReloadButtonInteractable(bool b)
    {
        _reloadButton.interactable = b;
    }
}
