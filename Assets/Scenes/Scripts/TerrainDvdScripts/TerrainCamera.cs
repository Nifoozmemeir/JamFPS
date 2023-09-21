using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCamera : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 movementLimits;
    private float targetHeight = 5.34f;
    private bool isRotating;
    [SerializeField] private float rotationSpeed;
    private Vector3 lastMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            Vector3 eulerAngleVelocity = new Vector3(0, mouseDelta.x, 0) * rotationSpeed;
            transform.Rotate(eulerAngleVelocity * Time.deltaTime);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirectionLocal = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveDirectionWorld = transform.TransformDirection(moveDirectionLocal);

        Vector3 newPosition = transform.position + moveDirectionWorld * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -movementLimits.x, movementLimits.x);
        newPosition.z = Mathf.Clamp(newPosition.z, -movementLimits.y, movementLimits.y);

        RaycastHit hit;
        if (Physics.Raycast(newPosition + Vector3.up * 1000f, Vector3.down, out hit))
        {
            float terrainHeight = hit.point.y;

            newPosition.y = terrainHeight + targetHeight;
        }

        transform.position = newPosition;
    }
}