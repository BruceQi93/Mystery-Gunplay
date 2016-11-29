/************************
 * Title:
 * Function：
 * 	－ 第三人称枪的控制
 * Used By：	
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;

public class RemoteGunController : MonoBehaviour {

    public GameObject muzzleFlash;//枪口的火花

    public void CreateMuzzleFlash()
    {
        //生成枪口火花效果
        muzzleFlash.SetActive(true);
    }

    public void DestroyMuzzleFlash()
    {
        //销毁爆炸效果
        muzzleFlash.SetActive(false);
    }
}
