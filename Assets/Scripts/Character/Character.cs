using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _health;

    protected virtual void Death()
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("получил урон");
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Death();
        }
    }
}
