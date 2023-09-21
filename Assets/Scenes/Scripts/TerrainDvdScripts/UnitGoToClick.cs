using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitGoToClick : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private bool isMoving;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        isMoving = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
                isMoving = true;
            }
        }

        if (isMoving && !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            isMoving = false;

            Vector3 worldPosition = transform.position;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            Vector3 screenPercentage = new Vector3(screenPosition.x / screenWidth, screenPosition.y / screenHeight, 0f);

            Debug.Log("World Position: " + worldPosition);
            Debug.Log("Screen Position (pixels): " + screenPosition);
            Debug.Log("Screen Position (Percentages): " + screenPercentage);
        }
    }
}