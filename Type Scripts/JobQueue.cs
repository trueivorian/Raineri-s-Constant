using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Code Source: http://stackoverflow.com/questions/10717344/c-sharp-creating-function-queue
public class JobQueue : MonoBehaviour {
    private Queue jobQueue;
    private bool isWorking;

    private void Update () {
        if (isWorking) {
            doJob();
        }
    }

    public bool isJobless {
        get {
            if (jobQueue.Count == 0) {
                return true;
            } else {
                return false;
            }
        }
    }

    public bool contains (Action job) {
        if (jobQueue.Contains(job)) {
            return true;
        } else {
            return false;
        }
    }

    public Action doJob () {
        return jobQueue.Dequeue() as Action;
    }

    public void addJob (Action<string, bool> job) {
        jobQueue.Enqueue(job);
    }

    public void setIsWorking (bool _isWorking) {
        this.isWorking = _isWorking;
    }
}
