using UnityEngine;
using System.Collections;

public abstract class Status {

    abstract public void modifyStatus (float difference);
    abstract public bool getIsReduced ();
    abstract public void setIsReduced (bool condition);

}
