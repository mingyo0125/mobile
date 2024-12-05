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

    private Player _player;
    public Player GetPlayer()
    {
        if (_playerTrm == null)
        {
            _player = FindAnyObjectByType<Player>();
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
}
