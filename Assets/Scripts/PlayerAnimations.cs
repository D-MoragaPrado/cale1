using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerWalk;

    private Animator _animator;
    private PlayerMovement _playermovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playermovement = GetComponent<PlayerMovement>();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateLayer();
        if (_playermovement.MovementOn)
        {
            _animator.SetFloat("x", _playermovement.MovementDirection.x);
            _animator.SetFloat("y", _playermovement.MovementDirection.y);
        }
        
    }

    private void ActivateLayer( string nameLayer)
    {
        /* for (int i =0 ; i<_animator.layerCount ; i++)
         {
             _animator.SetLayerWeight(i, 0);
         }
        */
        // _animator.SetLayerWeight(_animator.GetLayerIndex(nameLayer), 1);
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }

        _animator.SetLayerWeight(_animator.GetLayerIndex(nameLayer), 1);

    }

    private void UpdateLayer()
    {
        if (_playermovement.MovementOn)
        {
            ActivateLayer(layerWalk);
        }
        else
        {
            ActivateLayer(layerIdle);
        }
    }
}
