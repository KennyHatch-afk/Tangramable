using UnityEngine;

public class PieceDistance : MonoBehaviour
{
    public float maxDistance = 0f;

    public float UpdateDistance()
    {
        maxDistance -= 0.1f;

        return maxDistance;
    }
}
