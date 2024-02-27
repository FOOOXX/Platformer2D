using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private const string IsRunning = nameof(IsRunning);

    private Animator _animator;

    private int _isRunning;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _isRunning = Animator.StringToHash(IsRunning);
    }

    public void Move(float horizontalDirection)
    {
        _animator.SetBool(_isRunning, horizontalDirection != 0);
    }
}