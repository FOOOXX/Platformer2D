using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _amount = 0;

    public void Add(int amount)
    {
        _amount += amount;
    }
}
