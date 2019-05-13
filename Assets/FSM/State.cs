using System;
using System.Collections.Generic;

namespace FiveOTwoStudios.StateMachine
{
    public abstract class State<T>
    {
        protected T entity;
        public Dictionary<Func<bool>, State<T>> Transitions { get; set; }

        public State(T entity)
        {
            this.entity = entity;
            Transitions = new Dictionary<Func<bool>, State<T>>();
        }

        public void AddTransition(Func<bool> condition, State<T> newState)
        {
            Transitions.Add(condition, newState);
        }

        public abstract void StateUpdate(float deltaTime);

        public abstract void OnStateEnter();

        public abstract void OnStateExit();

    }
}