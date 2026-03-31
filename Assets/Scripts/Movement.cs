using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CircleCollider2D))]

public class Movement : MonoBehaviour, IDragHandler
{
    public Camera mainCam;
    public Vector3 circleDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;

        circleDistance = transform.position - transform.parent.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldMousePosition = mainCam.ScreenToWorldPoint(new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 1));

        worldMousePosition.z = transform.parent.position.z;

        transform.parent.position = worldMousePosition - circleDistance;
    }
}
