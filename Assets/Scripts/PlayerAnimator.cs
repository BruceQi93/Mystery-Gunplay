/************************
 * Title:
 * Function：
 * 	－ 控制角色动画
 * Used By：	Player
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

    public float jumpSpeed = 3;

    private Animator anim;
    private CharacterController cc;
	
	void Start () {
        anim = GetComponent<Animator>();
        cc = transform.root.GetComponent<CharacterController>();
	}
	
	void Update () {
        if (cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Jump");
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
                        anim.SetBool("CrouchWalk", true);
                    }
                    else
                    {
                        anim.SetBool("Run", true);
                    }
                }
                else
                {
                    anim.SetBool("CrouchWalk", false);
                    anim.SetBool("Run", false);

                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        anim.SetBool("Crouch", true);
                    }
                    else
                    {
                        anim.SetBool("Crouch", false);
                    }
                }
            }
        }
	}
}
