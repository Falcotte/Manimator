using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject backgroundObjectPrefab;
    [SerializeField] private List<GameObject> backgroundObjects = new List<GameObject>();

    [SerializeField] private float backgroundObjectHeightOffset;
    [SerializeField] private AnimationCurve backgroundCurve;
    [SerializeField] private float backgroundCurveMultiplier;

    [SerializeField] private float backgroundObjectDistance;
    [SerializeField] private Vector2 backgroundObjectFrequency;
    [SerializeField] private Vector2 backgroundObjectScale;

    [SerializeField] private float rotationSpeed;

    private float currentPlacementRotation;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void PlaceBackgroundObjects()
    {
        currentPlacementRotation = 0f;

        for(int i = 0; i < backgroundObjects.Count; i++)
        {
            DestroyImmediate(backgroundObjects[i].gameObject);
        }

        backgroundObjects.Clear();

        while(currentPlacementRotation < 360f)
        {
            float rotationToAdd = Random.Range(backgroundObjectFrequency.x, backgroundObjectFrequency.y);
            currentPlacementRotation += rotationToAdd;

            GameObject backgroundObject = Instantiate(backgroundObjectPrefab, transform);

            backgroundObject.transform.localPosition = new Vector3(0f, backgroundObjectHeightOffset + backgroundCurve.Evaluate(Mathf.InverseLerp(0f, 360f, currentPlacementRotation)) * backgroundCurveMultiplier, backgroundObjectDistance);
            backgroundObject.transform.RotateAround(transform.position, Vector3.up, currentPlacementRotation);
            backgroundObject.transform.localRotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            backgroundObject.transform.localScale = Vector3.one * Random.Range(backgroundObjectScale.x, backgroundObjectScale.y);

            backgroundObjects.Add(backgroundObject);
        }
    }
}
