using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SequenceMoveAndRotate : MonoBehaviour
{
    private void Start()
    {
        GameObject cube = this.gameObject;

        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(cube.transform.DOMove(new Vector3(5, 0, 0), 1));
        moveSequence.Append(cube.transform.DOMove(new Vector3(5, 5, 0), 1));
        moveSequence.Join(cube.transform.DORotate(new Vector3(90, 0, 0), 1));
        moveSequence.Append(cube.transform.DOMove(new Vector3(0, 5, 0), 1));
        moveSequence.Append(cube.transform.DOMove(new Vector3(0, 0, 0), 1));
        moveSequence.Join(cube.transform.DORotate(new Vector3(0, 0, 0), 1));
    }
}
