using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityFactory<T> : MonoBehaviour
{
    public PoolableMono SpawnObject(T type, Vector3 spawnTrm)
    {
        PoolableMono entity = Create(type);
        entity.transform.position = spawnTrm;
        entity.transform.rotation = Quaternion.identity;

        return entity;
    }

    protected abstract PoolableMono Create(T _type); //������ ���丮���� ������ �Ѵ�.
}
