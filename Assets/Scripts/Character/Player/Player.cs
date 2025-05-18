using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;

    public void FixedUpdate()
    {
        if(_inputReader.Direction != 0)
        {
            _playerMover.Move(_inputReader.Direction);
        }

        if (_inputReader.IsTryedToJump)
        {
            _playerMover.Jump();
            _inputReader.ResetJumpState();
        }
    }
}
