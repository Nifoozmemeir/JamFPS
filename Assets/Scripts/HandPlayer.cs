using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPlayer : MonoBehaviour
{
    [SerializeField] float radiusHandler;
    [SerializeField] SphereCollider sensorNear;
    public delegate void DelegateTake();
    public event DelegateTake OnTakeable;
    public event DelegateTake OnSightOut;
    [SerializeField] LayerMask layerMaskWeapon;
    [SerializeField] public GameObject target;
    private void Start()
    {
        sensorNear.radius = radiusHandler;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (layerMaskWeapon == (layerMaskWeapon | (1 << other.gameObject.layer)))
        {
            target = other.gameObject;
            OnTakeable?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (layerMaskWeapon == (layerMaskWeapon | (1 << other.gameObject.layer)))
        {
            if (target.transform.position == other.gameObject.transform.position)
            {                
                OnSightOut?.Invoke();
                target = null;
            }
            
        }
    }
}
