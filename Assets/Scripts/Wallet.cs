using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money = 0;

    public void Add(int amount)
    {
        _money += amount;
    }
}
