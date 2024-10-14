using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public GameObject projectilePrefab;  // Prefab do projétil
    public Transform firePoint;          // Ponto de disparo (a ponta do canhão)
    public float projectileSpeed = 20f;  // Velocidade do projétil
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();  // Agora também dispara projéteis
    }

    private void GetShootingInput()
    {
        // Detecta quando o botão esquerdo do mouse é pressionado
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instancia o projétil no ponto de disparo com a rotação atual da torreta
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Aplica movimento ao projétil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Define a velocidade do projétil com base na direção que a torreta está apontando
            rb.velocity = firePoint.right * projectileSpeed;
        }
    }
    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePositon());
    }

    private Vector2 GetMousePositon()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveBody?.Invoke(movementVector.normalized);
    }
}