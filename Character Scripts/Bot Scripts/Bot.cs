using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Only Bots are interactable with players
public abstract class Bot : Character, IInteractive {
    protected string description;
    protected List<string> dialogue;
    protected JobQueue botJobQueue;
    public List<string> getDialogues () {
        return this.dialogue;
    }

    public string getDescription () {
        return this.description;
    }

    public abstract void initializeDialogue (List<string> _dialogue);
}
