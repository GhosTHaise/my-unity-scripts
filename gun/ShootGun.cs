using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{

    public Rigidbody bulletCasing;
    public int ejectSpeed = 50;
    public float fireRate = 0.5f;
    
    private float nextFire = 0.0f;
    private bool fullAuto = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            
            Rigidbody bullet;
            bullet = Instantiate(bulletCasing,transform.position,transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.left * ejectSpeed);
            
        }
        if(Input.GetKeyDown("x")){
           fullAuto = !fullAuto;
        }
        
        if(fullAuto){
            fireRate = 0.10f;  
        }else{
            fireRate = 0.5f;
        }
    }
}
