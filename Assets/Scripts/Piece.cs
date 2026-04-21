using System;
using UnityEngine;

public class Piece : MonoBehaviour
{

    [SerializeField]
    protected Vector2 targetPosition;

    [SerializeField]
    protected float targetAngle;

    protected float positionTolerance = 0.3f;
    protected float angleTolerance = 10f;

    public bool correctSpot = false;

    public int id;

    void Start(){ }

    void Update()
    {
        correctSpot = isCorrect();
        if(correctSpot) SnapToTarget();
        else hasBeenSnapped = false;
    }

    public virtual bool isCorrect()
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

    private bool hasBeenSnapped = false;
    public void SnapToTarget()
    {
        if(!hasBeenSnapped)
        {
            AudioManager.Play("snap");
            hasBeenSnapped = true;
        }
        transform.localPosition = new Vector3(targetPosition.x, targetPosition.y, -1f);
        transform.localRotation = Quaternion.Euler(0, 0, targetAngle);
    }

}
