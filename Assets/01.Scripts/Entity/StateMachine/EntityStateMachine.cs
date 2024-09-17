using System;
using System.Collections;
using System.Collections.Generic;
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
            string newStateName = $"{entityType}{state.ToString()}State`2[{entityType}StateType, {entityType}]";
            Type type = Type.GetType(newStateName);

            try
            {
                EntityState<T, G> newState = Activator.CreateInstance(type, entity, this) as EntityState<T,G>;
                AddState(state, newState);
            }
            catch
            {
                Debug.LogError($"There is no script : {entityType}{state}State");

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

    public void ChangeState(EntityState<T, G> nextState)
    {
        CurrentState.ExitState();
        CurrentState = nextState;
        CurrentState.EnterState();
    }
}
