using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private readonly string ParameterIsRunning = "IsRunning";
    
    [SerializeField] private float _thershold = 0.1f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.SetBool(ParameterIsRunning, false);
    }

    private void Update()
    {
        bool isRunning = _rigidbody.linearVelocity.x > _thershold || _rigidbody.linearVelocity.x < -_thershold ;
        _animator.SetBool(ParameterIsRunning, isRunning);
    }
}
