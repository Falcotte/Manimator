using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    private Vector3 followOffset;

    private void Start()
    {
        followOffset = transform.position - followTarget.position;
    }

    private void LateUpdate()
    {
        transform.position = followTarget.position + followOffset;
    }
}
