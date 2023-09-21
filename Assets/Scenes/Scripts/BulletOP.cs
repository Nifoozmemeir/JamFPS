using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletOP : MonoBehaviour
{
    public static BulletOP Instance;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 24;
    private List<GameObject> pooledObjects;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        // Buscamos un objeto inactivo en el pool y lo devolvemos
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // Si no encontramos objetos inactivos, creamos uno nuevo y lo añadimos al pool
        GameObject newObj = Instantiate(bulletPrefab);
        newObj.SetActive(false);
        pooledObjects.Add(newObj);
        return newObj;
    }
}