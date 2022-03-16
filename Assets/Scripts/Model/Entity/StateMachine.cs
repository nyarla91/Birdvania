using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model.Entity
{
    public class StateMachine : MonoBehaviour
    {
        public const string Attack = "Attack";
        public const string Stun = "Stun";
        public const string Regular = "Regular";
        
        [SerializeField] private TextAsset _stateTable;
        [Header("RUNTIME DEBUG ONLY")]
        [SerializeField] private State _currentState;
        [SerializeField] private List<State> _states = new List<State>();

        public State CurrentState
        {
            get => _currentState;
            private set => _currentState = value;
        }

        public State GetState(string stateName) => _states.Find(state => state.Name.Equals(stateName));

        public bool TrySwitchToState(string newStateName)
        {
            State newState = _states.FirstOrDefault(state => state.Name.Equals(newStateName));
            if (newState == null || !CurrentState.CanSwitchToState(newStateName))
                return false;

            State oldState = CurrentState;
            CurrentState = newState;
            oldState.OnExit?.Invoke();
            newState.OnEnter?.Invoke();
            return true;
        }

        public bool IsCurrentState(string stateName) => CurrentState.Name.Equals(stateName);

        public bool IsCurrentStateOneOf(string[] stateNames) =>
            stateNames.Any(stateName => CurrentState.Name.Equals(stateName));

        public bool IsCurrentStateNoneOf(string[] statesNames) => !IsCurrentStateOneOf(statesNames);

        private void Awake()
        {
            GeneraleStateList();
        }

        private void GeneraleStateList()
        {
            string[] lines = _stateTable.text.Split('\n');
            
            List<string> stateNames = lines[0].Split(',').ToList();
            stateNames.RemoveAt(0);
            
            for (int y = 1; y < lines.Length; y++)
            {
                _states.Add(GenerateState(lines, y, stateNames));
            }
            CurrentState = _states[0];
        }

        private static State GenerateState(string[] lines, int y, List<string> stateNames)
        {
            string[] currentLine = lines[y].Split(',');
            List<string> forbiddenTransitions = new List<string>();
            for (int x = 1; x < currentLine.Length; x++)
            {
                if (currentLine[x].Equals("F"))
                    forbiddenTransitions.Add(stateNames[x - 1]);
            }
            State state = new State(currentLine[0], forbiddenTransitions);

            return state;
        }
    }

    [Serializable]
    public class State
    {
        [SerializeField] private string _name;
        [SerializeField] private List<string> _forbiddenTransitions;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Action OnEnter;
        public Action OnExit;

        public State(string name, List<string> frobiddenTransitions)
        {
            Name = name;
            _forbiddenTransitions = frobiddenTransitions;
        }

        public bool CanSwitchToState(string stateName) => !_forbiddenTransitions.Contains(stateName);
    }
}
