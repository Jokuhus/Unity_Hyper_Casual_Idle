using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private readonly GameObject _prefab;
    private readonly Queue<GameObject> _pool = new();

    public ObjectPool(GameObject prefab)
    {
        _prefab = prefab;
    }

    public GameObject Get(Vector3 position)
    {
        GameObject obj = _pool.Count > 0 ? _pool.Dequeue() : CreateNew();
        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }

    private GameObject CreateNew()
    {
        GameObject obj = Object.Instantiate(_prefab);
        obj.SetActive(false);
        return obj;
    }
}