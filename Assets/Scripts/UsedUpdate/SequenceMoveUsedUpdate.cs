using UnityEngine;
using System.Collections;

public class SequenceMoveUsedUpdate : MonoBehaviour
{
    private enum MoveState
    {
        Right,
        Up,
        Left,
        End,
    }

    private GameObject _cube;

    private MoveState _state;

    private Vector3 _movedRightEndPosition = new Vector3(5, 0, 0);

    private Vector3 _movedUpEndPosition = new Vector3(5, 5, 0);

    private Vector3 _movedLeftEndPosition = new Vector3(0, 5, 0);

    private void Start()
    {
        _cube = this.gameObject;
        _cube.transform.position = new Vector3(0, 0, 0);
        _state = MoveState.Right;
    }

    private void Update()
    {
        switch (_state)
        {
            case MoveState.Right:
                _cube.transform.position = Vector3.MoveTowards(_cube.transform.position, _movedRightEndPosition, 0.1f);
                if (_cube.transform.position == _movedRightEndPosition)
                {
                    _state = MoveState.Up;
                }
                break;
            case MoveState.Up:
                _cube.transform.position = Vector3.MoveTowards(_cube.transform.position, _movedUpEndPosition, 0.1f);
                if (_cube.transform.position == _movedUpEndPosition)
                {
                    _state = MoveState.Left;
                }
                break;
            case MoveState.Left:
                _cube.transform.position = Vector3.MoveTowards(_cube.transform.position, _movedLeftEndPosition, 0.1f);
                if (_cube.transform.position == _movedLeftEndPosition)
                {
                    _state = MoveState.End;
                }
                break;
            default:
                break;
        }
    }

}
