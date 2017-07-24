//A Limiter is a Decorator Task and therefore can only have on child.
//The Limiter evaluates its child only for a set amount of calls once
//that amount is reached, its will never evaluate again and always return
//FAILURE for its child from that point on.

using System.Collections;
using UnityEngine;

public class Limiter : Task {

	//Limiter Maximum Value
	protected int maxCalls;
	//Call count
	protected int callCount;

	//Child Task and it's getter
	protected Task childTask;
	public Task ChildTask{
		get{ return childTask;}
	}

	//Limiter Constructor
	public Limiter(Task _childTask, int _maxCalls){
		childTask = _childTask;
		maxCalls = _maxCalls;
	}

	//Evaluates the Task for a set amount of times and never calls it
	//again once the maximum amount of calls is reached. It will return FAILURE
	//from that point on.
	public override TaskStatus Evaluate(){
		if(callCount < maxCalls){
			switch(childTask.Evaluate()){
				case TaskStatus.FAILURE:
					currentTaskStatus = TaskStatus.FAILURE;
					callCount++;
					return currentTaskStatus;
				case TaskStatus.SUCCESS:
					currentTaskStatus = TaskStatus.SUCCESS;
					callCount++;
					return currentTaskStatus;
				case TaskStatus.WAITING:
					currentTaskStatus = TaskStatus.WAITING;
					callCount++;
					return currentTaskStatus;
			}
			currentTaskStatus = TaskStatus.SUCCESS;
			return currentTaskStatus;
		} else {
			currentTaskStatus = TaskStatus.FAILURE;
			return currentTaskStatus;
		}
	}
		
}
