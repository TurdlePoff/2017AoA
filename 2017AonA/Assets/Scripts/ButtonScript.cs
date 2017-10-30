using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    Transform thisButton;
    public class ButtonStats
    {
        public bool switchedOn = false;
    }


    public ButtonStats stats = new ButtonStats();
    
    public void Switch(bool val)
    {
        stats.switchedOn = val;
        if (stats.switchedOn)
        {
            //Destroy(gameObject);
        }
    }

}

