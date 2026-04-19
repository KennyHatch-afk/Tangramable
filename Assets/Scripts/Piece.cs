using System;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField]
    Vector2 targetPosition;

    [SerializeField]
    float targetAngle;

    private float positionTolerance = 0.3f;
    private float angleTolerance = 5f;

    public bool correctSpot = false;

    public int id;

    void Start(){ }

    void Update()
    {
        correctSpot = isCorrect();
        if(correctSpot) SnapToTarget();
    }

    public bool isCorrect()
    {
        float positionDifference = Vector2.Distance(transform.localPosition, targetPosition);
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle));

        return positionDifference <= positionTolerance && angleDifference <= angleTolerance;
    }

    public void SetTarget(Vector2 pos, float rot)
    {
        targetAngle = rot;
        targetPosition = pos;
    }

    public void SnapToTarget()
    {
        transform.localPosition = new Vector3(targetPosition.x, targetPosition.y, -1f);
        transform.localRotation = Quaternion.Euler(0, 0, targetAngle);
    }

}
