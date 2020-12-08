using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterGun : MonoBehaviour
{
    [Header("Gun Settings")]
    public int gunDamage = 25;
    public GameObject impactEffect;
    public Transform rayStart;
    public Transform rayEnd;

    private RaycastHit hit;
    private Ray ray;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.FireGun.performed += ctx => FireGun();
    }

    void FireGun()
    {
        ray = new Ray(rayStart.position, rayEnd.position);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.identity) as GameObject;
            Destroy(impactEffectGO, 5);
        }
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
