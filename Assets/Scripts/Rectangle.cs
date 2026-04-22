using UnityEngine;

public class Rectangle : Piece
{

    public override bool isCorrect()
    {
        float positionDifference = Vector2.Distance(transform.localPosition, targetPosition);

        float angleToTarget = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle));
        float angleToFlipped = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle + 180f));

        float angleDifference = Mathf.Min(angleToTarget, angleToFlipped);

        return positionDifference <= positionTolerance &&
               angleDifference <= angleTolerance;
    }

}
