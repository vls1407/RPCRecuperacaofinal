using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 10;
    public int damage = 5;
    public float maxDistance = 10;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb.velocity = transform.up * speed;    
    }
    void Start()
    { 
    
    }

    // Update is called once per frame
    void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= maxDistance ) 
        {
            DisableObject();
          
        }

    }

    private void DisableObject()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colidiu" + collision.name);

        var dano = collision.GetComponent<Dano>();
        if ( dano != null ) 
        {
            dano.Hit(damage);        
        }

        DisableObject();
    }
}
