using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public camera cam;
    [Header("GunSettins")]
    public int range;
    public float bullet=10;
    public float ShootCooldown=.4f;
    bool canShoot=true;
    [Header("Animator")]
    public Animator GunAnim;
   // public Animation ShootAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet >= 10)
        {
            bullet = 10;
        }
        if (Input.GetMouseButtonDown(0) && bullet>=1 && canShoot)
        {
            Shoot();
            canShoot = false;
            bullet--;
            StartCoroutine(Cooldown());
        }
        bullet += 0.0012f;
        Debug.Log(bullet);
    }
    private void Shoot()
    {
        GunAnim.SetTrigger("shoot");
        RaycastHit hit;
        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.CompareTag("enemy"))
            {
                
            }
        }

    }
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(ShootCooldown);
        canShoot = true;

    }
}
