using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity<PlayerStateType, Player>
{
    [Space]
    [SerializeField]
    private PlayerStatSO _playerStatSO; 

    private void Start()
    {
        base.Initialize();
    }

    protected override void Awake()
    {
		SetWeapon(transform.Find("EquipWeapon/WoodSword").GetComponent<Weapon>()); // ó������ �ϴ� �̰�

		base.Awake();
    }

    public void GetItem(Item item)
    {
        // Dosomething
    }

    protected override void CreateStateMachine()
    {
        StateMachine = new PlayerStateMachine(this);
    }

    public void SetWeapon(Weapon weapon)
    {
        EquipWeapon = weapon;
    }

    protected override void SetStat()
    {
        PlayerStat playerStat = new PlayerStat(_playerStatSO.PlayerStat);
        EntityStatController.Initialize(playerStat);
    }

    protected sealed override BaseStat GetStatSO()
    {
        if(_playerStatSO.PlayerStat != null)
        {
            return _playerStatSO.PlayerStat;
        }
        return null;
    }

    protected override string GetHudTextValue(float value)
    {
        return value.ToString();
    }
}
