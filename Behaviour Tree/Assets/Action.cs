//The Action is the leaf/end Task of our Behaviour Tree, it is
//the element that actually executes a given behaviour.
//This script is used as a generic which we will then pass a delegate.
//Important for making this approach work is the action delegate.
//You can implement whatever locig you want, however your method has to 
//return a TaskStatus in order to work. 


using System.Collections;
using UnityEngine;

public class Action : Task {

	//Method Signature for the action
	public delegate TaskStatus ActionTaskDelegate();

	//Delegate that is called to evaluate this task
	private ActionTaskDelegate action;

	//Action Constructor
	public Action(ActionTaskDelegate _action){
		action = _action;
	}

	//We are using a switch statement for evaluating the 
	//current tasks status.
	//You can switch the default return to whatever works best for you!
	public override TaskStatus Evaluate(){
		switch(action()){
			case TaskStatus.SUCCESS:
				currentTaskStatus = TaskStatus.SUCCESS;
				return currentTaskStatus;
			case TaskStatus.FAILURE:
				currentTaskStatus = TaskStatus.FAILURE;
				return currentTaskStatus;
			case TaskStatus.WAITING:
				currentTaskStatus = TaskStatus.WAITING;
				return currentTaskStatus;
			default:
				currentTaskStatus = TaskStatus.FAILURE;
				return currentTaskStatus;
		}
	}
}
