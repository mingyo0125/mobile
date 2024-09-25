using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity<PlayerStateType, Player>
{
	public void UpdateWeapon(Weapon weapon)
	{
        EquipWeapon = weapon;
	}

	private void Start()
    {
        StateMachine.Initialize(default);
        UpdateWeapon(transform.Find("Weapon").GetComponent<Weapon>());
	}

    protected override void CreateStateMachine()
    {
        StateMachine = new PlayerStateMachine(this);
    }
}
