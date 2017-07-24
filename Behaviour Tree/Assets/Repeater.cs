//A Repeater is a Decorator Task and therefore can only have on child.
//The Repeater evaluates its child until it either returns FAILURE or SUCCESS.

using System.Collections;
using UnityEngine;

public class Repeater : Task {

	//Child Task and it's getter
	protected Task childTask;
	public Task ChildTask{
		get{ return childTask;}
	}

	//Repeater Constructor
	public Repeater(Task _childTask){
		childTask = _childTask;
	}

	//Evaluates the Task until it either results in SUCCESS or FAILURE.
	public override TaskStatus Evaluate(){
		if(currentTaskStatus != TaskStatus.SUCCESS && currentTaskStatus != TaskStatus.FAILURE ){
			switch(childTask.Evaluate()){
				case TaskStatus.FAILURE:
					currentTaskStatus = TaskStatus.FAILURE;
					return currentTaskStatus;
				case TaskStatus.SUCCESS:
					currentTaskStatus = TaskStatus.SUCCESS;
					return currentTaskStatus;
				case TaskStatus.WAITING:
					currentTaskStatus = TaskStatus.WAITING;
					return currentTaskStatus;
				default:
					currentTaskStatus = TaskStatus.WAITING;
					return currentTaskStatus;
			}
		} else {
			return currentTaskStatus;
		}
	}
		
}
