using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerWalk;
    [SerializeField] private string Defeated;

    private Animator _animator;
    private PlayerMovement _playermovement;

    private readonly int directionX = Animator.StringToHash("x");
    private readonly int directionY = Animator.StringToHash("y");
    private readonly int defeated = Animator.StringToHash("Derrotado");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playermovement = GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateLayer();
        if (_playermovement.MovementOn == false)
        {
            return;
        }
        
        _animator.SetFloat(directionX, _playermovement.MovementDirection.x);
        _animator.SetFloat(directionY, _playermovement.MovementDirection.y);
        
        
    }

    private void ActivateLayer( string nameLayer)
    {
        
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

    private void PlayerDefeatedReply()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1   )
        {
            _animator.SetBool(Defeated , true);
        }
    }

    public void RevivePlayer()
    {
        ActivateLayer(layerIdle);
        _animator.SetBool(Defeated, false);

    }


    private void OnEnable()
    {
        PlayerLife.EventPlayerDefeated += PlayerDefeatedReply; 
    }

    private void OnDisable()
    {
        PlayerLife.EventPlayerDefeated -= PlayerDefeatedReply;
    }


}
