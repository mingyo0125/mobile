using UnityEngine;

public class CoinFactory : ObjectFactory<Coin>
{
    private PlayerStat _playerStat;

    private void Start()
    {
        _playerStat = GameManager.Instance.GetPlayerStat();
    }

    public void SpawnCoin(Vector2 spawnPos)
    {
        // ���߿� �ִ� ���� ���� ����� �ٸ���

        Coin spawnedCoin = SpawnObject("Coin", spawnPos) as Coin;
        float coinValue = 10f + Utils.CalculatePercent(10, _playerStat.DropCoinValue.Value); // �⺻������ 10

        spawnedCoin.SetCoinValue((int)coinValue);
    }
}
