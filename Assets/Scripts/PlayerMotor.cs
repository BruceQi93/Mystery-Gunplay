/************************
 * Title:
 * Function：
 * 	－ 
 * Used By：	player
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMotor : NetworkBehaviour {

    private CharacterController cc;
    private Vector3 moveSpeed;
    private bool isStep = false;
    private AudioSource au;

    void Start () {
        cc = GetComponent<CharacterController>();
        au = GetComponent<AudioSource>();
    }
	
    //FixedUpdate固定频率调用，所以将物理位移放在这里
	void FixedUpdate () {
        //判断是否是本地玩家
        if (!isLocalPlayer)
        {
            return;
        }

        cc.SimpleMove(moveSpeed);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isStep = true;
        }
        if (au.isPlaying)
        {
            isStep = false;
        }

        //播放脚步声
        if (cc.isGrounded && isStep)
        {
            au.Play();
        }
    }

    public void Move(Vector3 speed)
    {
        this.moveSpeed = speed;
    }

}
