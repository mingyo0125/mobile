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

        float dropCoinValue = 100f * WaveManager.Instance.CurStageCount;

        dropCoinValue += Utils.CalculatePercent(dropCoinValue, _playerStat.DropCoinValue.Value);

        spawnedCoin.SetCoinValue((int)dropCoinValue);
    }
}
