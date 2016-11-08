using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Code Source: http://stackoverflow.com/questions/10717344/c-sharp-creating-function-queue
public class JobQueue {

	private Queue jobQueue;
	private bool isWorking;

	public JobQueue(){
		this.jobQueue = new Queue();
		this.isWorking = false;
	}

	public void work(){
		if (this.isWorking) {
			this.doJob ();
		}
	}

	public bool isJobless{
		get{
			if (jobQueue.Count == 0) {
				return true;
			} else {
				return false;
			}
		}
	}

	public bool contains(Action job){
		if (jobQueue.Contains (job)) {
			return true;
		} else {
			return false;
		}
	}

	public Action doJob(){
		Debug.Log ("Working");
		return jobQueue.Dequeue () as Action;
	}

	public void addJob(Action job){
		jobQueue.Enqueue (job);
	}

	public void setIsWorking(bool _isWorking){
		this.isWorking = _isWorking;
	}
}
