using UnityEngine;

public class Rectangle : Piece
{

    public override bool isCorrect()
    {
        float positionDifference = Vector2.Distance(transform.localPosition, targetPosition);
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle));

        // Adjust the angle tolerance based on the rotation of the rectangle
        float adjustedAngleTolerance = angleTolerance;
        if (Mathf.Abs(transform.eulerAngles.z - targetAngle) > 180f)
        {
            adjustedAngleTolerance = 360f - angleTolerance;
        }

        return positionDifference <= positionTolerance && angleDifference <= adjustedAngleTolerance;
    }

}
