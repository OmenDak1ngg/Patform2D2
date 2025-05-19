using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private AnimatorController _animatorController;

    private float _threshold = 0.1f;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.Jumped += Jump;
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= Jump;
    }

    public void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            Move();
        }
    }

    private void Move()
    {
        _playerMover.Move(_inputReader.Direction);

        bool isRunning = Mathf.Abs(_rigidbody.linearVelocity.x) >= _threshold;
        _animatorController.RunAnimation(isRunning);
        
    }

    private void Jump()
    {
        _playerMover.Jump();
    }
}
