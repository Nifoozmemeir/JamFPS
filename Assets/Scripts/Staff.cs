using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Staff : MonoBehaviour
{
    [Header("My Body")]
    [SerializeField] public GameObject myArm;
    [SerializeField] public GameObject gunModel;
    [SerializeField] public GameObject gunShoot;
    [SerializeField] public BoxCollider gunCollider;
    [SerializeField] public bool secure;
    [Space]
    [Header("NaveMesh ToolKit")]
    [Tooltip("Referencia al transform del arma")]
    [SerializeField] public Transform weaponTransform;
    [Tooltip("Capa del NavMesh")]
    [SerializeField] public LayerMask navMeshLayer;
    [Tooltip("Altura objetivo (por ejemplo, 1 unidad)")]
    [SerializeField] public float targetHeight;

    void Start()
    {
        HandlerFinishFly(transform.position);
        
    }

    void Update()
    {
        if (!secure)
        {
            secure = true;
            gunShoot = myArm.GetComponent<Arm>().Shooting();
            Bullet bullet = gunShoot.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.OnFinishFly += HandlerFinishFly;
            }
            gunModel.SetActive(false);            
            transform.parent = null;
        }
    }
    private void HandlerFinishFly(Vector3 tPosition)
    {        
        gameObject.transform.position = tPosition;
        gunModel.SetActive(true);
        gunCollider.enabled = true;
        if (gunShoot != null)
        {
            Bullet bullet = gunShoot.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.OnFinishFly -= HandlerFinishFly;
            }
            gunShoot = null;
        }
        IOutPlataform();
    }
    public void IOutPlataform()
    {        
        if (!IsInNavMesh(weaponTransform.position))
        {            
            Vector3 closestPoint = GetClosestPointOnNavMesh(weaponTransform.position);
            closestPoint.y += targetHeight;
            weaponTransform.position = closestPoint;
        }
    }    
    private bool IsInNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(position, out hit, 0.1f, navMeshLayer);
    }
    private Vector3 GetClosestPointOnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 100f, navMeshLayer))
        {
            return hit.position;
        }
        return position;
    }
}
