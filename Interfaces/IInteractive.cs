using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IInteractive {

    /*
    * For long dialogues
    */
    List<string> getDialogues ();

    // For short descriptions
    string getDescription ();

    /*
    * Initializes the list of dialogues
    *
    * @params =
    * _dialogue: passes in an empty dialogue list for initialization.
    */
    void initializeDialogue (List<string> _dialogue);
}
