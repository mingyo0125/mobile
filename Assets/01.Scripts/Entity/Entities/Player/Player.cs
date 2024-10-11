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

    protected override void OnEnable()
    {
        base.OnEnable();

        Initialize();
    }

    protected override void Awake()
    {
		UpdateWeapon(transform.Find("EquipWeapon/WoodSword").GetComponent<Weapon>()); // 처음에는 일단 이것

		base.Awake();
    }

    public void GetItem(Item item)
    {

    }

    protected override void CreateStateMachine()
    {
        StateMachine = new PlayerStateMachine(this);
    }

    protected override void SetStat()
    {
        EntityStat = _playerStatSO.PlayerStat;
    }

    protected override BaseStat GetStat()
    {
        if(_playerStatSO.PlayerStat != null)
        {
            return _playerStatSO.PlayerStat;
        }
        return null;
    }
}
