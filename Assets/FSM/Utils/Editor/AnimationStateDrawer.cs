using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace net.fiveotwo.fsm
{
    [CustomPropertyDrawer(typeof(AnimationStateNameAttribute))]
    public class AnimationStateDrawer : PropertyDrawer
    {
        private int _index;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            StateMachineBehaviour stateMachineBehaviour = property.serializedObject.targetObject as StateMachineBehaviour;
            StateMachineBehaviourContext[] stateMachineBehaviourContext = AnimatorController.FindStateMachineBehaviourContext(stateMachineBehaviour);
            if (stateMachineBehaviourContext.Length <= 0)
            {
                return;
            }
            AnimatorController animatorController = stateMachineBehaviourContext[0].animatorController;

            if (animatorController != null)
            {
                List<string> states = new List<string>();
            
                foreach (AnimatorControllerLayer layer in animatorController.layers)
                {
                    foreach (ChildAnimatorState state in layer.stateMachine.states)
                    {
                        states.Add(state.state.name);
                    }
                }

                _index = states.FindIndex(value => value == property.stringValue);

                if (_index < 0)
                {
                    _index = 0;
                }
                
                _index = EditorGUI.Popup(position, label.text, _index, states.ToArray());

                if (states.Count >= _index)
                {
                    property.stringValue = states[_index];
                }
            }
        }
    }
}
