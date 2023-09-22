using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    private float startTimePoint;
    private bool startFly;
    [SerializeField] private float speedFly;

    public delegate void DelegateFlyFinish(Vector3 tPosition);
    public event DelegateFlyFinish OnFinishFly;
    private void Start()
    {
        startTimePoint = 0;
    }

    void Update()
    {
        if (CanFly())
        {
            startTimePoint += speedFly * Time.deltaTime;
            transform.Translate(new Vector3(0, 0, 1f) 
                * speedFly * Time.deltaTime);
        }
    }

    private bool CanFly() 
    {
        if (!startFly) return false;
        
        if (startTimePoint < maxDistance)
        {
             return true;
        }
        else
        {
            startTimePoint = 0;
            Vector3 tPosition = transform.position;
            OnFinishFly?.Invoke(tPosition);
            Destroy(this.gameObject);
        }
        return false;
    }
    public void StartFly()
    {
        startFly = true;
    }
}