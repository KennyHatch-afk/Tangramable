using UnityEngine;

public class StartText : MonoBehaviour
{
    private bool isGoingRight = true;
    public float speed;
    public float limits;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoingRight)
        {
            if(transform.rotation.z < -limits)
            {
                isGoingRight = !isGoingRight;
            }
            else
            {
                transform.Rotate(0, 0, -speed);
            }
        }
        else
        {
            if (transform.rotation.z > limits)
            {
                isGoingRight = !isGoingRight;
            }
            else
            {
                transform.Rotate(0, 0, speed);
            }
        }
    }
}
