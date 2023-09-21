using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpawner : MonoBehaviour
{
    public GameObject unit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 clickPoint = hit.point;
                GameObject newUnit = Instantiate(unit, clickPoint, Quaternion.identity);

                Vector3 terrainNormal = hit.normal;
                Quaternion unitRotation = Quaternion.LookRotation(Vector3.forward, terrainNormal);
                newUnit.transform.rotation = unitRotation;
            }
        }
    }
}