/************************
 * Title:
 * Function：
 * 	－ 控制枪的动画
 * Used By：	枪
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public GameObject muzzleFlash;//枪口的火花

    private Animation anim;
	
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	public void Fire()
    {
        //如果当前不是在重装子弹
        if (!anim.IsPlaying("Reload"))
        {
            //执行发射子弹动画
            //anim.Play("Fire");
            CreateMuzzleFlash();
            Invoke("DestroyMuzzleFlash", 0.02f);
        }
    }

    public void Reload()
    {
        anim.Play("Reload");
    }

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
