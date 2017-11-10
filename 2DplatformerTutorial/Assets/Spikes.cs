using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public static GameMaster gm; //instance of gm
    public static Player pl; //instance of gm

    public void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }

        if(pl == null)
        {
            pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update () {
        
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player") //Spikes
    //    {
    //        Debug.Log("AAAAAAAAA");
    //        pl.DamagePlayer(999999);
    //        //gm.KillPlayer(collision.gameObject.GetComponent<Player>());
    //    }
    //}
}
