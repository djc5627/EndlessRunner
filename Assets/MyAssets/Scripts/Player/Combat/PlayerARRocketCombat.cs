using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerARRocketCombat : PlayerCombatBase
{
    public Transform firePoint;
    public Transform projectileContainer;
    public GameObject rocketPrefab;
    public GameObject bulletPrefab;
    public GameObject rocketLauncherObj;
    public GameObject assaultRifleObj;
    public float shootForce_Rocket = 100f;
    public float shootDelay_Rocket = .5f;
    public float shootForce_Bullet = 100f;
    public float shootDelay_Bullet = .5f;
    public float hipFireSpread = 3f;
    public float aimDownSightsSpread = 0f;
    public AudioClip shootClip_Rocket;
    public float shootClipScale_Rocket = 1f;
    public AudioClip shootClip_Bullet;
    public float shootClipScale_Bullet = 1f;

    private float currentSpread;
    private float lastShootTime_Rocket = Mathf.NegativeInfinity;
    private float lastShootTime_Bullet = Mathf.NegativeInfinity;

    private void Awake()
    {
        currentSpread = hipFireSpread;
    }

    public override void Execute()
    {
        if (aimDownSightsHeld)
        {
            currentSpread = aimDownSightsSpread;
        }
        else
        {
            currentSpread = hipFireSpread;
        }

        if (primaryFireHeld)
        {
            ShootBullet();
        }

        if (secondaryFireHeld)
        {
            ShootRocket();
        }
    }

    private void ShootRocket()
    {
        if (lastShootTime_Rocket + shootDelay_Rocket > Time.time)
        {
            return;
        }

        //Rumble
        RumbleManager.Instance.StartRumble(.5f, .3f, .1f);

        GameObject tempRocket = Instantiate(rocketPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward), projectileContainer);
        Rigidbody rocketRb = tempRocket.GetComponent<Rigidbody>();
        rocketRb.AddForce(firePoint.forward * shootForce_Rocket);
        lastShootTime_Rocket = Time.time;

        GlobalAudioPlayer.Instance.PlayClipAt(shootClip_Rocket, transform.position, shootClipScale_Rocket);
        rocketLauncherObj.SetActive(true);
        assaultRifleObj.SetActive(false);
    }

    private void ShootBullet()
    {
        if (lastShootTime_Bullet + shootDelay_Bullet > Time.time)
        {
            return;
        }

        //Rumble
        RumbleManager.Instance.StartRumble(.1f, .15f, .015f);

        float spreadOffset = Random.Range(-currentSpread / 2f, currentSpread / 2f);
        Quaternion spreadRotation = firePoint.rotation * Quaternion.Euler(0f, spreadOffset, 0f);

        GameObject tempBullet = Instantiate(bulletPrefab, firePoint.position, spreadRotation, projectileContainer);
        Rigidbody bulletRb = tempBullet.GetComponent<Rigidbody>();        
        

        bulletRb.AddForce(tempBullet.transform.forward * shootForce_Bullet);
        lastShootTime_Bullet = Time.time;

        GlobalAudioPlayer.Instance.PlayClipAt(shootClip_Bullet, transform.position, shootClipScale_Bullet);
        rocketLauncherObj.SetActive(false);
        assaultRifleObj.SetActive(true);
    }
}
