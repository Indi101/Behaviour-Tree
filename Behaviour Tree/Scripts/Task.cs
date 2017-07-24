//This class provides the base functionality for all of our Tasks,
//as they will all derive from it.

using System.Collections;
using UnityEngine;

public abstract class Task {
	
	//Current status of the task and following its getter as
	//it should be protected and not be influenced from the Outside
	protected TaskStatus currentTaskStatus;
	public TaskStatus CurrentTaskStatus{
		get{ return currentTaskStatus;}
	}

	//Task Constructor
	public Task(){}

	//Delegate that returns the status of the task
	public delegate TaskStatus TaskReturn();

	//Method for evaluating the desired set of condions/tasks
	public abstract TaskStatus Evaluate();
	
}

//We will need an enum to define that TaskStatus, which can either be
//SUCCESS,FAILURE or WAITING.
public enum TaskStatus{
	SUCCESS,
	FAILURE,
	WAITING
}

