using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class JobQueue {

    private Queue<Action> jobQueue;
    private bool isWorking;

    public JobQueue () {
        this.jobQueue = new Queue<Action>();
        this.isWorking = false;
    }

    public void work () {
        //Debug.Log(this.isWorking);
        if (!this.isWorking) {
            this.doJob();
        }
    }

    public bool isJobless () {
        if (jobQueue.Count == 0) {
            return true;
        } else {
            return false;
        }
    }

    public bool contains (Action job) {
        if (jobQueue.Contains(job)) {
            return true;
        } else {
            return false;
        }
    }

    public void doJob () {
        if (!this.isJobless()) {
            (jobQueue.Dequeue())();
        } else {
            Debug.Log("Empty Queue");
        }
    }

    public void addJob (Action job) {
        jobQueue.Enqueue(job);
    }

    public void setIsWorking (bool _isWorking) {
        this.isWorking = _isWorking;
    }

    public void clear() {
        this.jobQueue.Clear();
        //Debug.Log(this.isJobless());
    }
}

