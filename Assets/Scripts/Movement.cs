using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Movement : MonoBehaviour
{
    public Camera mainCam;
    public Vector3 circleDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;

        circleDistance = transform.position - transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        Vector3 worldMousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        worldMousePosition.z = transform.parent.position.z;

        transform.parent.position = worldMousePosition - circleDistance;
    }
}
