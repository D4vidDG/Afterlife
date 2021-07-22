using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject subject;
    [SerializeField] int numberOfInstances;

    Queue<GameObject> objectQueue;

    private void Awake()
    {
        objectQueue = new Queue<GameObject>(numberOfInstances);
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
        if (objectQueue.Count != 0)
        {
            GameObject request = objectQueue.Dequeue();
            request.SetActive(true);
            return request;
        }

        return CreateSubject();
    }
}