using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerARRocketCombat : PlayerBehaviorBase
{
    public Transform firePoint;
    
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
    public float aimDownSightsTime = .1f;
    public AudioClip shootClip_Rocket;
    public float shootClipScale_Rocket = 1f;
    public AudioClip shootClip_Bullet;
    public float shootClipScale_Bullet = 1f;

    private Transform projectileContainer;
    private bool aimDownSightsHeld = false;
    private int startADSTweenId;
    private int stopADSTweenId;
    private float currentSpread;
    private float lastShootTime_Rocket = Mathf.NegativeInfinity;
    private float lastShootTime_Bullet = Mathf.NegativeInfinity;

    private void Awake()
    {
        projectileContainer = GameObject.Find("{PlayerProjectiles}").transform;
        currentSpread = hipFireSpread;
    }

    private void Start()
    {
        SwitchToAR();
    }

    protected override void SubscribeToInputEvents()
    {
        playerInput.onAimDownSights_Pressed += OnAimDownSights_Pressed;
        playerInput.onAimDownSights_Released += OnAimDownSights_Released;
    }

    public override void Execute()
    {
        bool primaryFireHeld = playerInput.GetIsPrimaryFireHeld();
        bool secondaryFireHeld = playerInput.GetIsSecondaryFireHeld();

        if (primaryFireHeld)
        {
            ShootBullet();
        }

        if (secondaryFireHeld)
        {
            ShootRocket();
        }

        UpdateAimAnim();
    }

    private void ShootBullet()
    {
        if (lastShootTime_Bullet + shootDelay_Bullet > Time.time)
        {
            return;
        }

        //Rumble
        InputDevice device = InputDeviceManager.GetPlayerDevice(playerInput.GetPlayerIndex());
        RumbleManager.Instance.StartRumble(device, .1f, .15f, .015f);

        float spreadOffset = Random.Range(-currentSpread / 2f, currentSpread / 2f);
        Quaternion spreadRotation = firePoint.rotation * Quaternion.Euler(0f, spreadOffset, 0f);

        GameObject tempBullet = Instantiate(bulletPrefab, firePoint.position, spreadRotation, projectileContainer);
        Rigidbody bulletRb = tempBullet.GetComponent<Rigidbody>();


        bulletRb.AddForce(tempBullet.transform.forward * shootForce_Bullet);
        lastShootTime_Bullet = Time.time;

        GlobalAudioPlayer.Instance.PlayClipAt(shootClip_Bullet, transform.position, shootClipScale_Bullet);
        SwitchToAR();
    }

    private void ShootRocket()
    {
        if (lastShootTime_Rocket + shootDelay_Rocket > Time.time)
        {
            return;
        }

        //Rumble
        InputDevice device = InputDeviceManager.GetPlayerDevice(playerInput.GetPlayerIndex());
        RumbleManager.Instance.StartRumble(device, .5f, .3f, .1f);

        GameObject tempRocket = Instantiate(rocketPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward), projectileContainer);
        Rigidbody rocketRb = tempRocket.GetComponent<Rigidbody>();
        rocketRb.AddForce(firePoint.forward * shootForce_Rocket);
        lastShootTime_Rocket = Time.time;

        GlobalAudioPlayer.Instance.PlayClipAt(shootClip_Rocket, transform.position, shootClipScale_Rocket);
        SwitchToRocket();
    }

    private void SwitchToAR()
    {
        rocketLauncherObj.SetActive(false);
        assaultRifleObj.SetActive(true);
        playerAnimController.SetIsUsingRocket(false);
    }

    private void SwitchToRocket()
    {
        rocketLauncherObj.SetActive(true);
        assaultRifleObj.SetActive(false);
        playerAnimController.SetIsUsingRocket(true);
    }

    private void OnAimDownSights_Pressed()
    {
        aimDownSightsHeld = true;

        float percentToAimSpread = Mathf.Abs(currentSpread - hipFireSpread) / Mathf.Abs(aimDownSightsSpread - hipFireSpread);
        float remainingTime = aimDownSightsTime * (1f - percentToAimSpread);

        //Tween spread to ADS
        LeanTween.cancel(stopADSTweenId);
        startADSTweenId = LeanTween.value(this.gameObject, v => currentSpread = v, currentSpread, aimDownSightsSpread, remainingTime).id;
        LeanTween.descr(startADSTweenId).setEaseInOutQuad();
    }

    private void OnAimDownSights_Released()
    {
        aimDownSightsHeld = false;

        float percentToHipSpread = Mathf.Abs(currentSpread - aimDownSightsSpread) / Mathf.Abs(aimDownSightsSpread - hipFireSpread);
        float remainingTime = aimDownSightsTime * (1f - percentToHipSpread);

        //Tween spread to ADS
        LeanTween.cancel(startADSTweenId);
        stopADSTweenId = LeanTween.value(this.gameObject, v => currentSpread = v, currentSpread, hipFireSpread, remainingTime).id;
        LeanTween.descr(stopADSTweenId).setEaseInOutQuad();
    }

    private void UpdateAimAnim()
    {
        float aimPercent = (currentSpread - hipFireSpread) / (aimDownSightsSpread - hipFireSpread);
        playerAnimController.SetADSPercent(aimPercent);
    }
}
