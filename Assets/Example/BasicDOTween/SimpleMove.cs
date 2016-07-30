using UnityEngine;
using System.Collections;

// DOTween を使用するときは DG.Tweening を using に入れる
using DG.Tweening;

public class SimpleMove : MonoBehaviour
{
    private void Start()
    {
        GameObject cube = this.gameObject;
        // DOTween の初期化(必ず呼ぶ必要がある)
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

        cube.transform.DOMove(new Vector3(5, 0, 0), 1);
    }
}
