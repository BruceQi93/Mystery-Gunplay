/************************
 * Title:
 * Function：
 * 	－ 切换枪支，
 * Used By：	WeaponManager
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;
using System;

public class WeaponsManager : MonoBehaviour {

    //存放毎把枪的脚本组件
    public GunController[] guns;
    //记录换枪的顺序
    private int index = 0;

	void Update () {
        //按下Q键，切换枪支
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchGun();
        }
        //按下R键Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            guns[index].Reload();
        }
        //按下鼠标左键发射
        if (Input.GetMouseButtonDown(0))
        {
            guns[index].Fire();
        }
	}

    //切换枪支
    private void SwitchGun()
    {
        guns[index].gameObject.SetActive(false);
        index++;
        index %= guns.Length;
        guns[index].gameObject.SetActive(true);
    }
}
