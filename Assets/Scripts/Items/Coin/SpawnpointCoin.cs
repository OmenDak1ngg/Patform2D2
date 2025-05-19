using UnityEngine;

public class SpawnpointCoin : MonoBehaviour
{
    [SerializeField] private int _layerMaskIndex;

    private void Start()
    {
        gameObject.layer = _layerMaskIndex;
    }
}
