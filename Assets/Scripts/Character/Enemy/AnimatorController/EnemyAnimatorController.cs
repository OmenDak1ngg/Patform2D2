using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimatorController : MonoBehaviour
{
    private readonly string ParameterAttacked = "Attacked";

    private Animator _animator;

    private void Start()
    {
        _animator  = GetComponent<Animator>();
    }

    public void MeleeAttackAnimation()
    {
        _animator.SetTrigger(ParameterAttacked);
    }
}
