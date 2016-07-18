using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;

    private void Start()
    {
        DOTween.Init();
    }

    public void ChangeScene()
    {
        DOTween.Sequence()
            .Append(_fadeImage.DOColor(new Color(0, 0, 0, 1), 1))
            .OnComplete(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("NextScene");
    }
}
