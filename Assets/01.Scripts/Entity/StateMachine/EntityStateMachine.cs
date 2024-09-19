using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class EntityStateMachine<T, G> where T : Enum where G : Entity<T, G>
{
    public EntityState<T, G> CurrentState { get; private set; }

    public Dictionary<T, EntityState<T, G>> StateDictionary
        = new Dictionary<T, EntityState<T, G>>();

    public EntityStateMachine(Entity<T, G> entity)
    {
        foreach (T state in Enum.GetValues(typeof(T)))
        {
            Type entityType = entity.GetType();
            //string newStateName = $"{entityType}{state}State`2[{entityType}StateType, {entityType}]"; // 만약 STate가 제네릭이면 이렇게
            string newStateName = $"{entityType}{state}State";
            Type type = Type.GetType(newStateName);

            if(type == null)
            {
                Debug.LogError($"State type not found: {newStateName}");
                return;
            }

            try
            {
                EntityState<T, G> newState = Activator.CreateInstance(type, entity as G, this) as EntityState<T,G>;
                AddState(state, newState);
            }
            catch(Exception ex)
            {
                Debug.LogError($"Failed to create state {newStateName}: {ex.Message}");
            }
        }
    }

    private void AddState(T stateEnum, EntityState<T, G> state)
    {
        StateDictionary.Add(stateEnum, state);
    }

    public void Initialize(T entityState)
    {
        CurrentState = StateDictionary[entityState];
        CurrentState.EnterState();
    }

    public void ChangeState(T nextState)
    {
        CurrentState.ExitState();
        CurrentState = StateDictionary[nextState];
        CurrentState.EnterState();
    }
}
