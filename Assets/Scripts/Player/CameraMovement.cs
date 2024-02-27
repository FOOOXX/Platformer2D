using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private readonly float _speed = 0.12f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _speed);
    }
}
