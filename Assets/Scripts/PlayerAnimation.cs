/************************
 * Title:
 * Function：
 * 	－ 控制player动画的播放
 * Used By：	AnimSolider
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    public float jumpSpeed = 2;

    private Animation anim;
    private CharacterController cc;
	
	void Start () {
        anim = GetComponent<Animation>();
        cc = transform.root.GetComponent<CharacterController>();
	}

    void Update()
    {
        //是否在地上
        if (cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //PlayAnim("StandingJump");
                GetComponent<Animation>().Play("StandingJump");
                anim["StandingJump"].speed = 0.2f;
                cc.Move(Vector3.up * jumpSpeed);
                AudioManager.PlayEffectAu("BodyJump");
            }
            else
            {
                float hor = Input.GetAxisRaw("Horizontal");
                float ver = Input.GetAxisRaw("Vertical");

                if (Mathf.Abs(hor) > 0.05f || Mathf.Abs(ver) > 0.05f)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        PlayAnim("CrouchWalk");
                    }
                    else
                    {
                        PlayAnim("RunAim");
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        PlayAnim("Crouch");
                    }
                    else
                    {
                        PlayAnim("StandIdle2");
                    }
                }
            }
        }
    }

    void PlayAnim(string animName)
    {
        anim.CrossFade(animName, 0.2f);
    }
}
