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
    
    [SerializeField] private float speed;

    public Vector3 PointForMove => _waypoint.GetMovementDirection(pointActualIndex);

    protected Waypoint _waypoint;
    protected Animator _animator;
    protected int pointActualIndex;
    protected Vector3 LastPosition;

    private void Start()
    {
        pointActualIndex = 0;
        _animator = GetComponent<Animator>();
        _waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        MovePersonaje();
        RotatePersonaje();
        RotateVertical();

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

    protected virtual void RotatePersonaje()
    {
        
    }

    protected virtual void RotateVertical()
    {

    }

}
