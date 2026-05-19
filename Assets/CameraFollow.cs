using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _smoothSpeed = 5f;

    private void LateUpdate()
    {
        if (_target == null) return;
        Vector3 targetPos = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, _smoothSpeed * Time.deltaTime);
    }
}
