/************************
 * Title:
 * Function：
 * 	－ 处理Player的血量
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
using UnityEngine.UI;

public class PlayerHealth : NetworkBehaviour {

    public int maxHp = 100;
    [SyncVar(hook ="OnChangeHealth")]
    public int currentHp;
    public Slider hpSlider;

    void Start()
    {
        currentHp = maxHp;
    }
	
    public void TakeDamage(int damage)
    {
        //只在服务器端执行
        if (!isServer) return;       

        currentHp -= damage;
        if (currentHp<=0)
        {
            //游戏结束
            currentHp = 0;
            Application.Quit();
        }
    }

    void OnChangeHealth(int hp)
    {
        hpSlider.value = hp / (float)maxHp;
    }
}
