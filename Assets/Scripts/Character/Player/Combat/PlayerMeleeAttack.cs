using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private int _damage;
    [SerializeField] private Transform _reference;
    [SerializeField] private LayerMask _enemyLayerMask;

    public void OnAttack()
    {
        Collider2D hittedEnemy = Physics2D.OverlapCircle(_reference.position, _attackRadius, _enemyLayerMask);

        if(hittedEnemy == null)
            return;

        hittedEnemy.GetComponent<Enemy>().TakeDamage(_damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_reference.position, _attackRadius);
    }
}
