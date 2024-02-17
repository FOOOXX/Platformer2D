using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] private int _amount;
    public int Amount => _amount;
}
