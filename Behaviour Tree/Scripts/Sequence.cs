//The Sequence is a composite Task and therefore can possibly have
//one or more children, thats why we use a List to hold the Children.
//During the evaluation we picture all of the childTasks as SUCCESS,
//only if they evaluate to be FAILURE the entire Sequence fails.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Task {

	//Sequence child Tasks
	protected List<Task> childTasks = new List<Task>();

	//Sequence Contructor
	public Sequence(List<Task> _childTasks){
		childTasks = _childTasks;
	}

	//We are using a switch statement to evaluate the childTasks
	//If any of the children returns a FAILURE - we will report it upwards.
	//Only if all children return SUCCESS, we can report a SUCCESS.
	public override TaskStatus Evaluate(){
		bool tasksRunning = false;

		for(int i = 0; i < childTasks.Count; i++){
			Task currentTask = childTasks[i];
			switch(currentTask.Evaluate()){
				case TaskStatus.FAILURE:
					currentTaskStatus = TaskStatus.FAILURE;
					return currentTaskStatus;
				case TaskStatus.SUCCESS:
					continue;
				case TaskStatus.WAITING:
					tasksRunning = true;
					continue;
				default:
					currentTaskStatus = TaskStatus.SUCCESS;
					return currentTaskStatus;
			}
		}
		if(tasksRunning == true){
			currentTaskStatus = TaskStatus.WAITING;
			return currentTaskStatus;
		} else {
			currentTaskStatus = TaskStatus.SUCCESS;
			return currentTaskStatus;
		}
	}
}
