//An Inverter is a Decorator Task and therefore can only
//have on child.
//The Inverter works like the ! Operator. It turns the result
//into its opposite if its either SUCCESS or FAILURE.
//However, WAITING will be handled regularly.

using System.Collections;
using UnityEngine;

public class Inverter : Task {

	//Child Task and it's getter
	protected Task childTask;
	public Task ChildTask{
		get{ return childTask;}
	}

	//Inverter Constructor
	public Inverter(Task _childTask){
		childTask = _childTask;
	}

	//Inverts the Result
	public override TaskStatus Evaluate(){
		switch(childTask.Evaluate()){
			case TaskStatus.FAILURE:
				currentTaskStatus = TaskStatus.SUCCESS;
				return currentTaskStatus;
			case TaskStatus.SUCCESS:
				currentTaskStatus = TaskStatus.FAILURE;
				return currentTaskStatus;
			case TaskStatus.WAITING:
				currentTaskStatus = TaskStatus.WAITING;
				return currentTaskStatus;
		}
		currentTaskStatus = TaskStatus.SUCCESS;
		return currentTaskStatus;
	}
}
