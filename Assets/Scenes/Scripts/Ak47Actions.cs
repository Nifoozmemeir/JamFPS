using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Ak47Actions : MonoBehaviour
{
    [SerializeField] private Transform shoot;
    [SerializeField] private KeyCode myKey;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifetime;

    private void Update()
    {
        GameObject projectile = null;

        if (Input.GetKeyDown(myKey))
        {
            projectile = BulletOP.Instance.GetPooledObject();
        }
        if (projectile != null)
        {
            projectile.transform.position = shoot.position;
            projectile.transform.rotation = shoot.rotation;
            projectile.SetActive(true);

            float bulletVelocity = bulletSpeed * Time.deltaTime;
            projectile.transform.Translate(Vector3.forward * bulletVelocity);

            if (Time.time - lifetime > bulletVelocity)
            {
                projectile.SetActive(false);
                projectile = null;
            }
        }
    }
}