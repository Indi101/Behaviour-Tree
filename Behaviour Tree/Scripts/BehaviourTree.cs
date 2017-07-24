using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour {

	//TASKS:
	//Add all the different types of tasks you will need for 
	//your behaviour tree here
	public Selector rootTask;
	public Action branchTaskA;
	public Inverter branchTaskB;
	public Action branchTaskC;
	public Action leafTask;

	//Placeholder values for DoSomething and DoSomethingElse
	public int a;
	public int b;

	private void Start(){
		InstantiateBehaviourTree();
	}

	private void InstantiateBehaviourTree(){
		//Instantiate your Behaviour Tree divided into its different tiers starting
		//from its leaf tasks

		//Action / Leaf Tasks
		leafTask = new Action(DoSomething);

		//Second Tier / Branch Tasks
		branchTaskA = new Action (DoSomethingElse);
		branchTaskB = new Inverter (leafTask);      //Because the leafTask is the Inverters child
		branchTaskC = new Action(DoSomethingElse);

		//Third Tier / Root Task
		//Prepare list of all its children
		List<Task> rootChildren = new List<Task>();
		rootChildren.Add(branchTaskA);
		rootChildren.Add(branchTaskB);
		rootChildren.Add(branchTaskC);

		rootTask = new Selector(rootChildren);
		
	}

	//Action delegates always have to return a TaskStatus - use your own logic
	//and adjust them to your needs, these are just placeholders to visualize
	//how the implementation works.
	private TaskStatus DoSomething(){
		if(a == 50){
			return TaskStatus.SUCCESS;
		} else {
			return TaskStatus.FAILURE;
		}
	}

	private TaskStatus DoSomethingElse(){
		a += 50;
		if(a == 50){
			return TaskStatus.SUCCESS;
		} else {
			return TaskStatus.FAILURE;
		}
	}
}
