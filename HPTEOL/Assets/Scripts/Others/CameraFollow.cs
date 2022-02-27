using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    private Transform followTarget;

    private void Start()
    {
        followTarget = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.position + offset, 3 * Time.fixedDeltaTime);
    }
}
