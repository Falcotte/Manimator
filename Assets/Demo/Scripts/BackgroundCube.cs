using UnityEngine;

public class BackgroundCube : MonoBehaviour
{
    [SerializeField] private Vector2 rotationSpeed;
    private Vector3 rotationVector;

    private void Start()
    {
        rotationVector = Random.insideUnitSphere * Random.Range(rotationSpeed.x, rotationSpeed.y);
    }

    private void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
