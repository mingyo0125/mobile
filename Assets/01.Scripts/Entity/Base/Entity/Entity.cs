using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public abstract partial class Entity<T, G> : PoolableMono where T : Enum where G : Entity<T, G>
{
    public EntityStateMachine<T, G> StateMachine { get; private set; }

    protected virtual void Awake()
    {
        StateMachine = new EntityStateMachine<T, G>(this as G); // G�� ����Ͽ� ���¸ӽ��� �ʱ�ȭ
        InitializeMoveable();

        StateMachine.Initialize(default);
    }

    private void Update()
    {
        StateMachine.CurrentState?.UpdateState();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState?.FixedUpdateState();
    }
}
