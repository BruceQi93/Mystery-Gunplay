/************************
 * Title:
 * Function：
 * 	－ 管理所有玩家的控制血量的脚本
 * Used By：	null
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private static Dictionary<uint, PlayerHealth> playerHealthDic = new Dictionary<uint, PlayerHealth>();

    //注册netid
    public static void Register(uint netid,PlayerHealth playerhealth)
    {
        playerHealthDic.Add(netid, playerhealth);
    }

    //注销
    public static void UnRegister(uint netid)
    {
        if (playerHealthDic.ContainsKey(netid))
        {
            playerHealthDic.Remove(netid);
        }
    }

    //根据netid得到playerHealth
    public static PlayerHealth GetPlayer(uint netid)
    {
        if (playerHealthDic.ContainsKey(netid))
        {
            return playerHealthDic[netid];
        }
        return null;
    }
}
