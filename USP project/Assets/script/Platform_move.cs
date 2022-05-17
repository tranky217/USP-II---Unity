using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_move : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    private int currentPointIdx = 0;
    // Start is called before the first frame update
    [SerializeField] private float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(points[currentPointIdx].transform.position, transform.position) < 1f)
        {
            currentPointIdx++;
            if (currentPointIdx >= points.Length)
            {
                currentPointIdx = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIdx].transform.position, Time.deltaTime * speed);
    }
}
