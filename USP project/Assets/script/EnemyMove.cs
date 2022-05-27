using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    [SerializeField] private GameObject[] points;
    private int currentPointIdx = 0;
    private SpriteRenderer enemy;
    // [SerializeField] private float speed = 1.5f;

    private void Start()
    {
        enemy = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // check for the distance of points and enemy => change direction
        if (Vector2.Distance(points[currentPointIdx].transform.position, transform.position) < 1f)
        {
            if (currentPointIdx == 0)
            {
                enemy.flipX = true;
            }
            else
            {
                enemy.flipX = false;
            }
            currentPointIdx++;
            if (currentPointIdx >= points.Length)
            {
                currentPointIdx = 0;
            }
            // transform.position = Vector2.MoveTowards(transform.position, points[currentPointIdx].transform.position, Time.deltaTime * speed);
        }
    }
}
