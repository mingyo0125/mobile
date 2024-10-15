using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity<PlayerStateType, Player>
{
    [SerializeField]
    private PlayerStatSO _playerStatSO; 

	public void UpdateWeapon(Weapon weapon)
	{
        EquipWeapon = weapon;
	}

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach(StatType a in Enum.GetValues(typeof(StatType)))
            {
                Debug.Log($"{a}: {EntityStatController.GetStatValue(a)}");
            }
        }
    }

    private void Start()
    {
        base.Initialize();
    }

    protected override void Awake()
    {
		UpdateWeapon(transform.Find("EquipWeapon/WoodSword").GetComponent<Weapon>()); // 처음에는 일단 이것

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

    protected override void SetStat()
    {
        EntityStatController = new PlayerStatController();
        EntityStatController.Initialize(_playerStatSO.PlayerStat);
    }

    protected sealed override BaseStat GetStat()
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
