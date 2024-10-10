using DG.Tweening;
using System.Collections;
using UnityEngine;

public abstract class Item : PoolableMono
{
    [SerializeField]
    private Transform _minBounds, _maxBounds;

    [SerializeField]
    private bool isBouncing;

    private void Start()
    {
        StartCoroutine(SpawnTwinkleCorou());


        if(isBouncing)
        {
            Vector3 originPos = transform.position;

            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(transform.DOLocalMoveY(originPos.y + 0.05f, 0.5f)).SetRelative().SetEase(Ease.Linear)
                .Append(transform.DOLocalMoveY(originPos.y - 0.05f, 0.5f)).SetEase(Ease.Linear)
                //.Append(transform.DOLocalMoveY(originPos.y, 0.25f)).SetEase(Ease.Linear)
                .SetLoops(-1);
        }
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
                Vector2 spawnPos = GetTwinklePos(i);
                PoolableMono twinkle = PoolManager.Instance.CreateObject("Twinkle");
                twinkle.transform.SetParent(transform);
                twinkle.transform.localPosition = spawnPos;

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(2f);
        }
        
    }

    private Vector2 GetTwinklePos(int i)
    {
        if(i <= 0)
        {
            return _minBounds.localPosition;
        }

        return _maxBounds.localPosition;
    }
}
