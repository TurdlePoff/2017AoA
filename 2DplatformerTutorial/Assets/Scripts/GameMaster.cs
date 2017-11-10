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
    public Transform currentSpawnPoint;
    public float spawnDelay = 2;
    public Transform spawnPlayerPrefab;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public IEnumerator RespawnPlayer()
    {
        //GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, currentSpawnPoint.position, currentSpawnPoint.rotation);
        Transform spawnParticles = Instantiate(spawnPlayerPrefab, currentSpawnPoint.position, currentSpawnPoint.rotation);
        Destroy(spawnParticles.gameObject, 3f);
        //SceneManager.LoadScene.LoadLevel("Level1");
        //Application.LoadLevel();
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

	public static void KillEnemy(Enemy enemy)
	{
		Destroy (enemy.gameObject);
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

    public void NextLevel()
    {
        Debug.Log("LEVEL WON");
    }

    public static void ButtonGateHandler(RaycastHit2D hit)
    {
        ButtonSwitcher bSwitch = GameObject.FindGameObjectWithTag("RedSwitch").GetComponent<ButtonSwitcher>();
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
                case "bButton1":
                {
                    bSwitch = GameObject.FindGameObjectWithTag("bSwitch1").GetComponent<ButtonSwitcher>();
                    WeaponSwitchButtons(bSwitch);
                    break;
                }
                case "bButton2":
                {
                    bSwitch = GameObject.FindGameObjectWithTag("bSwitch2").GetComponent<ButtonSwitcher>();
                    WeaponSwitchButtons(bSwitch);
                    break;
                }
                case "bButton3":
                {
                    bSwitch = GameObject.FindGameObjectWithTag("bSwitch3").GetComponent<ButtonSwitcher>();
                    WeaponSwitchButtons(bSwitch);
                    break;
                }
                case "bButton4":
                {
                    bSwitch = GameObject.FindGameObjectWithTag("bSwitch4").GetComponent<ButtonSwitcher>();
                    WeaponSwitchButtons(bSwitch);
                    break;
                }
                case "bButton5":
                {
                    bSwitch = GameObject.FindGameObjectWithTag("bSwitch5").GetComponent<ButtonSwitcher>();
                    WeaponSwitchButtons(bSwitch);
                    break;
                }
                case "bButton6":
                    {
                        bSwitch = GameObject.FindGameObjectWithTag("bSwitch6").GetComponent<ButtonSwitcher>();
                        WeaponSwitchButtons(bSwitch);
                        break;
                    }

            }
        }
    }


}