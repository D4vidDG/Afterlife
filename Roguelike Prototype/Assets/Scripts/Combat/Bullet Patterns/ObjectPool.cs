using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject subject;
    [SerializeField] float numberOfInstances;

    Queue<GameObject> objectQueue;

    private void Awake()
    {
        for (int i = 0; i < numberOfInstances; i++)
        {

            objectQueue.Enqueue(CreateSubject());
        }
    }

    private GameObject CreateSubject()
    {
        GameObject instance = Instantiate(subject, transform.position, Quaternion.identity, this.transform);
        instance.SetActive(false);
        return instance;
    }

    public GameObject RequestSubject()
    {
        if (objectQueue.Count != 0) return objectQueue.Dequeue();

        return CreateSubject();
    }
}