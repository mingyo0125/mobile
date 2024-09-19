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
            _playerTrm = GameObject.Find("Player").transform;
        }
        return _playerTrm;
    }
}
