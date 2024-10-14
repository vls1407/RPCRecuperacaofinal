using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public List<Transform> torretaBarrels;
    public GameObject balaPrefab;
    public float reloadDelay = 1;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    public float currentDelay = 0;

    public void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in torretaBarrels) 
            {
                GameObject bala = Instantiate(balaPrefab);
                bala.transform.position = barrel.position;
                bala.transform.localRotation = barrel.rotation;
                bala.GetComponent<Bala>().Initialize();
                foreach (var collider  in tankColliders)
                {
                    Physics2D.IgnoreCollision(bala.GetComponent<Collider2D>(), collider);
                }
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (canShoot == false) 
       {
        currentDelay -= Time.deltaTime;
            if (currentDelay <= 0) 
            {
                canShoot = true;            
            }
       }
    }

}
