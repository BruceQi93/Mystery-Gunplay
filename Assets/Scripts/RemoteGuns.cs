/************************
 * Title:
 * Function：
 * 	－ 第三人称枪的控制
 * Used By：	RemoteGuns
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;
using System;

public class RemoteGuns : MonoBehaviour {

    //存放毎把枪的脚本组件
    public RemoteGunController[] remoteGuns;
    //记录换枪的顺序
    private int index = 0;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchGun();
        }
	}

    //切换枪支
    private void SwitchGun()
    {
        remoteGuns[index].gameObject.SetActive(false);
        index++;
        index %= remoteGuns.Length;
        remoteGuns[index].gameObject.SetActive(true);
    }
}
