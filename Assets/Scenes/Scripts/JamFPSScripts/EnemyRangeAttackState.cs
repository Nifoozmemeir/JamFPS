using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttackState : State
{
    [SerializeField] private State walkState;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletShoot;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;
    private float attackTimer = 2f;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float detectionRadius;

    public override State RunCurrentState()
    {
        Collider[] players = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

        if (players.Length > 0)
        {
            if (CanAttack())
            {
                Shoot();
            }
        }
        else
        {
            return walkState;
        }

        return this;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletShoot.position, bulletShoot.rotation);
        bullet.transform.rotation = Quaternion.Euler(90.0f, bulletShoot.rotation.eulerAngles.y, bulletShoot.rotation.eulerAngles.z);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    private bool CanAttack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= fireRate)
        {
            attackTimer = 0.0f;
            return true;
        }

        return false;
    }
}