using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    private Transform followTarget;
    [SerializeField] float smoothness;

    private void Start()
    {
        followTarget = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, followTarget.position + offset, smoothness * Time.fixedDeltaTime);
    }
}