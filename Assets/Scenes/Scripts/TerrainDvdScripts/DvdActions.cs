using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvdActions : MonoBehaviour
{
    [SerializeField] private float speed;
    private Camera myCamera;
    private Vector3 move;

    private void Start()
    {
        myCamera = Camera.main;
        move = new Vector3(1, 0, 1).normalized;
    }

    private void Update()
    {
        Vector2 screenPos = myCamera.WorldToScreenPoint(this.transform.position);

        if (screenPos.x >= Screen.width || screenPos.x <= 0)
        {
            move.x *= -1;
        }

        if (screenPos.y >= Screen.height || screenPos.y <= 0)
        {
            move.z *= -1;
        }

        this.transform.Translate(move * speed * Time.deltaTime);
    }
}