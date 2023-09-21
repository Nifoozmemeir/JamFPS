using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior
{
    [SerializeField] private float maxHp;
    public float currentHp;
    private float maxRaycastDistance = 2;
    [SerializeField] private float heal;
    [SerializeField] private float wDamage;

    public Warrior (float maxHp)//, float currentHp, float maxRaycastDistance, float heal, float wDamage)
    {
        //this.maxHp = maxHp;
        //this.currentHp = currentHp;
        //this.maxRaycastDistance = maxRaycastDistance;
        //this.heal = heal;
        //this.wDamage = wDamage;

        currentHp = maxHp;
    }

    private void Awake()
    {
        currentHp = maxHp;
    }

    //private void Update()
    //{
    //    WarriorAttack();
    //    Dead();

    //    if (Input.GetKey(KeyCode.R))
    //    {
    //        HealWarrior();
    //    }
    //}

    //private void WarriorAttack()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, maxRaycastDistance))
    //    {
    //        Debug.Log("Warrior attacked");
    //        DamageWarrior();
    //    }
    //}

    //private void HealWarrior()
    //{
    //    if (currentHp + heal < maxHp)
    //    {
    //        currentHp += heal;
    //    }
    //}

    //public void DamageWarrior()
    //{
    //    currentHp -= wDamage;
    //}

    //private void Dead()
    //{
    //    if (currentHp <= 0)
    //    {
    //        Debug.Log("I Warrior I'm death :(");
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(transform.position, transform.forward);
    //}
}