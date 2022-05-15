using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Vector2[] points;
    public Vector2[] Points => points;


    public Vector2 ActualPosition { get; set; }
    private bool gameOn;

    private void Start()
    {
        gameOn = true;
        ActualPosition = transform.position;
    }


    private void OnDrawGizmos()
    {
        if (gameOn == false && transform.hasChanged)
        {
            ActualPosition = transform.position;
        }


        if (points == null || points.Length <=0)
        {
            return;
        }

        for(int i=0; i < points.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(points[i] + ActualPosition, 15f);
            if( i < points.Length-1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + ActualPosition , points[i + 1] + ActualPosition);
            }

        }
    }
}
