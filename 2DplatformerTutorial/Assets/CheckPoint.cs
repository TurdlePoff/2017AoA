using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    // Use this for initialization
    public static GameMaster gm; //instance of gm
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            Debug.Log("asdjbakjsd");
        gm.currentSpawnPoint = gameObject.transform;
    }
}
