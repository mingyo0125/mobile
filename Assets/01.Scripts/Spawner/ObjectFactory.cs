using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectFactory<T> : MonoBehaviour where T : PoolableMono
{
    [SerializeField]
    private SpawnEntityTypes _spawnEntityTypes;

    protected T[] _spawnEntitys; // 이 팩토리에서 소환할 오브젝트들

    public PoolableMono SpawnObject(string crateEntityName, Vector3 spawnTrm)
    {
        PoolableMono entity = Create(crateEntityName);
        entity.transform.position = spawnTrm;
        entity.transform.rotation = Quaternion.identity;

        return entity;
    }

    protected virtual void Awake()
    {
        SetSpawnEntityByType();
    }

    private void SetSpawnEntityByType()
    {
        switch (_spawnEntityTypes)
        {
            case SpawnEntityTypes.Enemies:
                SetSpawnEntities(PoolManager.Instance.PoolObjSO.Enemies);
                break;
            case SpawnEntityTypes.Items:
                SetSpawnEntities(PoolManager.Instance.PoolObjSO.Items);
                break;
            case SpawnEntityTypes.ETC:
                SetSpawnEntities(PoolManager.Instance.PoolObjSO.ETC);
                break;
            case SpawnEntityTypes.Coins:
                SetSpawnEntities(PoolManager.Instance.PoolObjSO.Coins);
                break;
            case SpawnEntityTypes.UI:
                SetSpawnEntities(PoolManager.Instance.PoolObjSO.UI);
                break;
            default:
                Debug.LogError($"{_spawnEntityTypes} Type is not set");
                break;
        }
    }

    private void SetSpawnEntities(List<PoolObjectsInfo> poolObjects)
    {
        _spawnEntitys = new T[poolObjects.Count];

        for (int i = 0; i < poolObjects.Count; i++)
        {
            _spawnEntitys[i] = poolObjects[i].PoolObject as T;
        }
    }

    protected virtual PoolableMono Create(string crateEntityName)
    {
        return PoolManager.Instance.CreateObject(crateEntityName);
    }
}
