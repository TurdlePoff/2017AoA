using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm; //instance of gm

    public void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2;
    public Transform spawnPlayerPrefab;


    public IEnumerator RespawnPlayer()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Transform spawnParticles = Instantiate(spawnPlayerPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(spawnParticles.gameObject, 3f);
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }
    
    public static void WeaponSwitchButtons(ButtonSwitcher bSwitch)
    {
        if (bSwitch.switchedOn)
        {
            bSwitch.switchedOn = false;
        }
        else
        {
            bSwitch.switchedOn = true;
        }
    }

    public static void ButtonGateHandler(RaycastHit2D hit)
    {
        ButtonSwitcher bSwitch = GameObject.FindGameObjectWithTag("BlueSwitch").GetComponent<ButtonSwitcher>();
        if (bSwitch != null) // || gSwitch != null 
        {
            switch (hit.transform.gameObject.tag)
            {
                case "RedButton":
                {
                    bSwitch = GameObject.FindGameObjectWithTag("RedSwitch").GetComponent<ButtonSwitcher>();
                    WeaponSwitchButtons(bSwitch);

                    break;
                }
                case "BlueButton":
                {
                    bSwitch = GameObject.FindGameObjectWithTag("BlueSwitch").GetComponent<ButtonSwitcher>();
                    WeaponSwitchButtons(bSwitch);

                    break;
                }
                case "GreenButton":
                {
                    bSwitch = GameObject.FindGameObjectWithTag("GreenSwitch").GetComponent<ButtonSwitcher>();
                    WeaponSwitchButtons(bSwitch);
                    break;
                }
            }
        }
    }


}