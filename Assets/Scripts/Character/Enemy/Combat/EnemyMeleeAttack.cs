using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _mask; 

    public void OnAttack()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, transform.localScale, 0f, _mask);

        if (collider == null) 
            return;

        if(collider.TryGetComponent(out Player player) == false)
                return;

        player.TakeDamage(_damage);
    }
}
