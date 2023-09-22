using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public GameObject Shooting()
    {
        Vector3 recamara = transform.position;
        GameObject munition = GameObject.Instantiate(
            bullet,
            recamara,
            transform.rotation
        );
        munition.GetComponent<Bullet>().StartFly();
        return munition;
    }
    
}
