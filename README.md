# FSM

It's a generic state machine that allows to define states and transitions for any entity on you game. The goal of the FSM is to provide a way to handle an entity behaviour state, transitions and to help to mantain an reuse code.

![alt fsm](https://github.com/riktothepast/FSM/blob/master/fsm.png)

### Creating a new FSM

Just create a new Script that inherits from BehaviourFSM.

```C#
public class Robot : BehaviourFSM
```

Then you can assign it to a `GameObject` and start assigning States and Transitions

![alt fsm](https://github.com/riktothepast/FSM/blob/master/FSMInEditor.PNG)


#### SetState(BehaviourState state)
Assigns the current state of the FSM, will execute the `OnStateEnter` of the new assigned method and `OnStateExit` of the current state if available.

# State

A state provides several methods for you to implement. A `State` has a `boolean` property called `defaultState` if active will set the `State` as the initial state of the FSM.

#### OnStateEnter()
When the FSM receives a state change, will execute this method. Use this method to initialize the state logic.

#### OnStateExit()
Prior to remove the current state of the FSM on a transition, it will call `OnStateExit`. Useful to reset variables of the state to it's defaults and be ready for a next invocation.

#### ReinitializeTransitions()
This allows you to call the `Reset` method in each `Transition` of a given `State`.

# Transitions

A transition allows to change the current State, a State can transit to different new states based on the rules you define in each transtion.
To create a new transition you need to inherit from `TransitionEvent`

A transition defines the following methods:

#### Evaluate
This `boolean` method will be evaluated each frame while the current state that uses this transition runs, once it returns `true` it will trigger the state change.

#### Initialize(BehaviourFSM fsm)
This will be called when the FSM is initialized, allows you to define the initial state of you transition as needed.

#### Reset
You can use this method to reset the transition if needed (e.g. Reset variables for the next time this transition runs).


# Update

### Update types
You can define how the FSM should update, it supports Unity's update types as follows:

##### Update
##### LateUpdate
##### FixedUpdate
##### ManualUpdate *

* For `ManualUpdate` you need to manually call the method `StateUpdate`
#### StateUpdate(float deltaTime)
This method will be updated by the FSM update loop, here you will define the correspondent behaviour of your state, it receives a `deltaTime` if you wish to override the default delta step.


# Check the included demo
![alt fsm](https://github.com/riktothepast/FSM/blob/master/roboCollector.gif)

Assets provided by https://kenney.nl/
