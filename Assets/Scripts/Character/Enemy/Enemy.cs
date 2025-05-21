using UnityEditorInternal;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyAnimator _animatorController;
    [SerializeField] private EnemyVision _vision;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Patroller _patroller;

    private void OnEnable()
    {
        _vision.PlayerDetected += OnDetectedPlayer;
        _vision.PlayerNotVisible += OnPlayerNotVisible;
    }

    private void OnDisable()
    {
        _vision.PlayerDetected -= OnDetectedPlayer;
        _vision.PlayerNotVisible -= OnPlayerNotVisible;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _animatorController.MeleeAttackAnimation();
        }
    }

    private void OnDetectedPlayer(Player player)
    {
        _mover.StartChasingPlayer(player);
    }

    private void OnPlayerNotVisible()
    {
        _mover.LostPlayer();
    }
}   
