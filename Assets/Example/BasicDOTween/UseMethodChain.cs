using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UseMethodChain : MonoBehaviour
{
    private void Start()
    {
        GameObject cube = this.gameObject;
        DOTween.Sequence()
            .Append(cube.transform.DOMove(new Vector3(5, 0, 0), 1))
            .Append(cube.transform.DOMove(new Vector3(5, 5, 0), 1))
            .Join(cube.transform.DORotate(new Vector3(90, 0, 0), 1))
            .Append(cube.transform.DOMove(new Vector3(0, 5, 0), 1))
            .Append(cube.transform.DOMove(new Vector3(0, 0, 0), 1))
            .Join(cube.transform.DORotate(new Vector3(0, 0, 0), 1));
    }
}
