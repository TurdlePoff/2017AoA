using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    [System.Serializable]

    public class ButtonStats
    {
        public bool switchedOn = false;

        //public void KillPlayer();
    }


    public ButtonStats buttonStats = new ButtonStats();
    public int fallYBoundary = -20;
    
    public void Switch(bool val)
    {
        buttonStats.switchedOn = val;
        if (buttonStats.switchedOn)
        {
            GameMaster.SwitchButton(this);
        }
    }

}

