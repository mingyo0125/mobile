using UnityEngine;

public class CoinFactory : EntityFactory<Coin>
{
    private PlayerStat _playerStat;

    private void Start()
    {
        _playerStat = GameManager.Instance.GetPlayerStat();
    }

    public void SpawnCoin(Vector2 spawnPos)
    {
        // 나중에 주는 돈에 따라 생긴거 다르게

        Coin spawnedCoin = SpawnObject("Coin", spawnPos) as Coin;

        float coinValue = 10f + Utils.CalculatePercent(10, _playerStat.DropCoinValue); // 기본적으로 10

        spawnedCoin.SetCoinValue((int)coinValue);
    }
}
