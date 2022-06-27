using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody2D;
    private Vector2 direction;
}
