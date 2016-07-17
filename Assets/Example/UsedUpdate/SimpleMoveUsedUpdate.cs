using UnityEngine;

/// <summary>
/// Update で GameObject を動かしてみる
/// </summary>
public class SimpleMoveUsedUpdate : MonoBehaviour
{
    private GameObject _cube;

    private void Start()
    {
        _cube = this.gameObject;
        _cube.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        _cube.transform.position = Vector3.MoveTowards(_cube.transform.position, new Vector3(5, 0, 0), 0.1f);
    }
}
