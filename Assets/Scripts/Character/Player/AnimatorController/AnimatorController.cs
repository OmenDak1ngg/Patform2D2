using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private readonly string ParameterIsRunning = "IsRunning";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(ParameterIsRunning, false);
    }

    public void RunAnimation(bool isRunnning)
    {
        _animator.SetBool(ParameterIsRunning, isRunnning);
    }
}
