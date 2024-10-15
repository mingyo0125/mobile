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
            _playerTrm = FindAnyObjectByType<Player>().transform;
        }
        return _playerTrm;
    }

    private Player _player;
    public Player GetPlayer()
    {
        if (_playerTrm == null)
        {
            _player = GetPlayerTrm().GetComponent<Player>();
        }
        return _player;
    }

    private PlayerStat _playerStat;
    public PlayerStat GetPlayerStat()
    {
        if (_playerStat == null)
        {
            _playerStat = GetPlayerTrm().GetComponent<Player>().EntityStatController.EntityStat as PlayerStat;
        }
        return _playerStat;
    }
}
