using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity<PlayerStateType, Player>
{
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
		UpdateWeapon(transform.Find("EquipWeapon/WoodSword").GetComponent<Weapon>()); // ó������ �ϴ� �̰�

		base.Awake();
	}

    public void GetItem(Item item)
    {

    }

    protected override void CreateStateMachine()
    {
        StateMachine = new PlayerStateMachine(this);
    }
}
