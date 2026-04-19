using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.UIElements;

[RequireComponent(typeof(CircleCollider2D))]

public class Movement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Camera mainCam;
    public Vector3 circleDistance;
    public PieceDistance pieceTracker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pieceTracker = GameObject.FindGameObjectWithTag("PT").GetComponent<PieceDistance>();

        mainCam = Camera.main;

        circleDistance = transform.position - transform.parent.position;

        circleDistance.z = transform.position.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldMousePosition = mainCam.ScreenToWorldPoint(new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 1));

        worldMousePosition.z = transform.position.z;

        transform.parent.position = worldMousePosition - circleDistance;
        //transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -1f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent.Translate(0, 0, -1f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0f);
    }
}
