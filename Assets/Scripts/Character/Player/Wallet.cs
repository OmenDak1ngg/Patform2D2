using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coinsCount;

    private void Start()
    {
        _coinsCount = 0;
    }

    public void AddCoin()
    {
        _coinsCount ++;
        Debug.Log("��������� �������: ����� " + _coinsCount);
    }
}
