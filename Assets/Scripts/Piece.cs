using System;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField]
    Vector2 targetPosition;

    [SerializeField]
    float targetAngle;

    private float positionTolerance = 0.5f;
    private float angleTolerance = 5f;

    public bool correctSpot = false;

    public int id;

    void Start(){ }

    void Update()
    {
        correctSpot = isCorrect();
    }

    public bool isCorrect()
    {
        float positionDifference = Vector2.Distance(transform.position, targetPosition);
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle));

        return positionDifference <= positionTolerance && angleDifference <= angleTolerance;

    }

    public void SetTarget(Vector2 pos, float rot)
    {
        targetAngle = rot;
        targetPosition = pos;
    }

}
