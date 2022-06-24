using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MovementDirection
{
    Horizontal,
    Vertical
}
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private MovementDirection direction;
    [SerializeField] private float speed;

    public Vector3 PointForMove => _waypoint.GetMovementDirection(pointActualIndex);

    private Waypoint _waypoint;
    private int pointActualIndex;
    private Vector3 LastPosition;

    private void Start()
    {
        pointActualIndex = 0;
        _waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        MovePersonaje();

        if (CheckActualPointReached())
        {
            UpdateIndexMovement();
        }
    }

    private void MovePersonaje()
    {
        transform.position = Vector3.MoveTowards(transform.position, PointForMove, speed * Time.deltaTime);
    }

    private bool CheckActualPointReached()
    {
        float distance = (transform.position - PointForMove).magnitude;
        if (distance < 0.1f)
        {
            LastPosition = transform.position;
            return true;
        }
        return false;
    }

    private void UpdateIndexMovement()
    {
        if(pointActualIndex == _waypoint.Points.Length - 1)
        {
            pointActualIndex = 0;
        }
        else
        {
            if (pointActualIndex < _waypoint.Points.Length - 1)
            {
                pointActualIndex ++;
            }
        }
    }

    private void RotatePersonaje()
    {
        if(direction != MovementDirection.Horizontal)
        {
            return;
        }

        if(PointForMove.x > LastPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
