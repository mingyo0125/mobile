using System.Collections;
using UnityEngine;

public abstract class Item : PoolableMono
{
    [SerializeField]
    private Transform _minBounds, _maxBounds;

    private void Start()
    {
        StartCoroutine(SpawnTwinkleCorou());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            GetItem(player);
            PoolManager.Instance.DestroyObject(this);
        }
    }

    protected abstract void GetItem(Player player);

    private IEnumerator SpawnTwinkleCorou()
    {
        while(true)
        {
            for(int i = 0; i < 2; i++)
            {
                Vector2 spawnPos = Utils.GetRandomSpawnPos(_minBounds.position, _maxBounds.position);
                PoolableMono twinkle = PoolManager.Instance.CreateObject("Twinkle");
                twinkle.transform.position = spawnPos;
                twinkle.SetPosition(transform.position);

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(2f);
        }
        
    }

}
