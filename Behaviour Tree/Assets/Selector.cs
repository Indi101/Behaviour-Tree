//The Selector is a composite Task and therefore can possibly have
//one or more children, thats why we use a List to hold the Children.
//During the evaluation we run through all of its children and evaluate
//each one individually. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Task {

	//Selectors child Tasks
	protected List<Task> childTasks = new List<Task>();

	//Selector Contructor
	public Selector(List<Task> _childTasks){
		childTasks = _childTasks;
	}

	//We are using a switch statement to evaluate the childTasks
	//If any of the children returns a SUCCESS - we will report it upwards.
	//Else, we will report failure instead.
	public override TaskStatus Evaluate(){
		for(int i = 0; i < childTasks.Count; i++){
			Task currentTask = childTasks[i];
			switch(currentTask.Evaluate()){
				case TaskStatus.FAILURE:
					continue;
				case TaskStatus.SUCCESS:
					return currentTaskStatus;
				case TaskStatus.WAITING:
					return currentTaskStatus;
				default:
					continue;
			}
		}
		currentTaskStatus = TaskStatus.FAILURE;
		return currentTaskStatus;
	}
}
