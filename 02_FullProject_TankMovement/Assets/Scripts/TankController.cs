using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankMover tankMover;
    public MiraTorreta miraTorreta;
    public Torreta[] torretas;

    private void Awake()
    {
        if(tankMover == null)
           tankMover = GetComponentInChildren<TankMover>();
        if (miraTorreta == null)
            miraTorreta = GetComponentInChildren<MiraTorreta>();
        if (torretas == null || torretas.Length == 0)
        {
            torretas = GetComponentInChildren<Torreta[]>();
        }
    }

    public void HandleShoot()
    {
       foreach (var torreta in torretas)
       {
            torreta.Shoot();  
       }
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMover.Move(movementVector);
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        miraTorreta.Aim(pointerPosition);
    }
    
}
