using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyAnimatorController _animatorController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _animatorController.MeleeAttackAnimation();
        }
    }
}
