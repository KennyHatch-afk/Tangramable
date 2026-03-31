using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Rotation : MonoBehaviour
{
    public Camera mainCam;
    public Vector3 unitCircleVector;
    public Vector3 unitMouseVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
    }

    void OnMouseDrag()
    {
        Vector3 worldMousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        unitCircleVector = transform.position - transform.parent.position;
        unitCircleVector.z = 0;
        unitMouseVector = worldMousePosition - transform.parent.position;
        unitMouseVector.z = 0;

        Vector3 cross = Vector3.Cross(unitMouseVector, unitCircleVector);
        float temp = Vector3.SignedAngle(unitCircleVector, unitMouseVector, Vector3.forward);

        //Debug.DrawLine(transform.parent.position, transform.parent.position + unitCircleVector, Color.green);
        //Debug.DrawLine(transform.parent.position, transform.parent.position + unitMouseVector, Color.red);
        //Debug.Log(temp);

        transform.parent.transform.Rotate(0, 0, temp);
    }
}
