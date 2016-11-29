/************************
 * Title:
 * Function：
 * 	－ 
 * Used By：	
 * Author:	
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour{

    public Transform bulletSpawn;//子弹发射点
    public GameObject bullet;
    public int damage = 10;

	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        //按下鼠标左键发射子弹
        if (Input.GetMouseButtonDown(0))
        {
            CmdShoot();
            AudioManager.PlayEffectAu("PistolFire");
        }
    }
    
    [Command]
    void CmdShoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);             
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,100))
        {
            //处理一些行为
            GameObject b = null;
             b= Instantiate(bullet, hit.point, Quaternion.identity)as GameObject;
            AudioManager.PlayEffectAu("Bullet");
            NetworkServer.Spawn(b);

            if (hit.collider.transform.root.CompareTag("Player"))
            {
                PlayerHealth health = GameManager.GetPlayer(hit.collider.transform.root.GetComponent<NetworkIdentity>().netId.Value);                
                health.TakeDamage(damage);
            }
        }
    }
   
}
