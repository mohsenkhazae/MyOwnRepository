using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public GameObject fireEffect;
    public int countShoot;

    public void Fire()
    {
        if (countShoot < 2)
        {
            GameObject cloneprojectile = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
            cloneprojectile.GetComponent<Rigidbody>().AddForce(cloneprojectile.transform.forward * 5000, ForceMode.Acceleration);
            fireEffect.GetComponent<ParticleSystem>().Play();
            cloneprojectile.GetComponent<explosion>().Artillery = this;
            countShoot++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
