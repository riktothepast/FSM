# FSM

It's a generic state machine that allows to define states and transitions for any entity on you game. The goal of the FSM is to provide a way to handle an entity behaivour state, transitions and to help to mantain an reuse code.

[[https://github.com/riktothepast/fsm/blob/master/img/fsm.png|alt=fsm]]

### Creating a new FSM

```C#
FSM<Robot> stateMachine;
stateMachine = new FSM<Robot>();
```
#### SetState(State<T> state)
Assigns the current state of the FSM, will execute the `OnStateEnter` of the new assigned method and `OnStateExit` of the current state if available.

#### Update(float deltaTime)
Updates the current state and check for posible transitions, it receives a `deltaTime` variable for further calculations in each state update

# State

A state provides several methods for you to implement

#### OnStateEnter()
When the FSM receives a state change, will execute this method. Use this method to initialize the state logic.

#### OnStateExit()
Prior to remove the current state of the FSM on a transition, it will call `OnStateExit`. Useful to reset variables of the state to it's defaults and be ready for a next invocation.

#### StateUpdate(float deltaTime)
This method will be updated by the FSM update loop, here you will define the correspondent behaviour of your state, it receives a `deltaTime` if you wish to override the default delta step.

#### AddTransition(Func<bool> condition, State<T> newState)
Adds a condition (a `boolean` function) when this condition is met, the FSM will change the `currentState` to the `newState` defined in this transition.


# Check the included demo

[[https://github.com/riktothepast/fsm/blob/master/img/roboCollector.gif|alt=roboCollector]]
Assets provided by https://kenney.nl/