/************************
 * Title:
 * Function：
 * 	－ 不是本地玩家的将移动的脚本和camera的audiolistener组件
 * Used By：	Player
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerInit : NetworkBehaviour {

    public Behaviour[] componentToDisable;
   
	void Start () {
        if ( ! isLocalPlayer)
        {
            DisableComponent();
        }      
	}

    //在客户端开启就根据netid注册playerhealth
    public override void OnStartClient()
    {
        GameManager.Register(GetComponent<NetworkIdentity>().netId.Value, GetComponent<PlayerHealth>());
    }

    void DisableComponent()
    {
        foreach (Behaviour component in componentToDisable)
        {
            component.enabled = false;
        }
    }

    //当脚本禁用时注销
    void OnDisable()
    {
        GameManager.UnRegister(GetComponent<NetworkIdentity>().netId.Value);
    }
}
