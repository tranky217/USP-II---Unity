using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D body2d;
    [SerializeField] private float leftPush;
    [SerializeField] private float rightPush;
    [SerializeField] private float velocityThreshold;
    void Start()
    {
        leftPush = -0.2f;
        rightPush = -0.2f;
        velocityThreshold = 100;
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }
    private void Push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightPush && body2d.angularVelocity > 0
        && body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > leftPush && body2d.angularVelocity < 0
        && body2d.angularVelocity > velocityThreshold * -1)
        {
            body2d.angularVelocity = velocityThreshold * -1;
        }
    }
}
