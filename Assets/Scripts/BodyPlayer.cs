using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPlayer : MonoBehaviour
{
    public delegate void DelegateTouch(GameObject toucher);
    public event DelegateTouch OnTouchForEnemy;
    public event DelegateTouch OnTouchForBullet;
    [SerializeField] LayerMask layerMaskEnemy;
    [SerializeField] LayerMask layerMaskShoot;


    private void OnTriggerEnter(Collider other)
    {
        
        if (layerMaskEnemy == (layerMaskEnemy | (1 << other.gameObject.layer)))
        {            
            OnTouchForEnemy(other.gameObject);
        }
        if (layerMaskShoot == (layerMaskShoot | (1 << other.gameObject.layer)))
        {
            
            OnTouchForBullet(other.gameObject);
        }
    }
}
