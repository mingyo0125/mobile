using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleTon<GameManager>
{
    private Transform _playerTrm;
    public Transform GetPlayerTrm()
    {
        if(_playerTrm == null)
        {
            _playerTrm = GetPlayer().transform;
        }
        return _playerTrm;
    }

    public Vector3 LastPlayerPos { get; private set; } 
    public void SetLastPlayerPos(Vector3 pos)
    {
        LastPlayerPos = pos;
    }

    private Player _player;
    public Player GetPlayer()
    {
        if (_playerTrm == null)
        {
            _player = FindAnyObjectByType<Player>();

            if (_player == null)
            {
                Debug.Log("Player is null. Create Player");
                PoolManager.Instance.CreateObject("MagicPlayer").SetPosition(_startTrm.position);
                _player = FindAnyObjectByType<Player>();
            }
        }
        return _player;
    }

    private PlayerStat _playerStat;
    public PlayerStat GetPlayerStat()
    {
        if (_playerStat == null)
        {
            _playerStat = GetPlayer().EntityStatController.EntityStat as PlayerStat;
        }
        return _playerStat;
    }

    [SerializeField]
    private Transform _startTrm;

}
