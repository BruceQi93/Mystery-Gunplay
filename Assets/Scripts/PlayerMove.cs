/************************
 * Title:
 * Function：
 * 	－ 控制player移动
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

public class PlayerMove : NetworkBehaviour {

    private PlayerMotor motor;
    private float speed = 3;
	
	void Start () {
        motor = GetComponent<PlayerMotor>();
	}

    void Update () {
        //判断是否是本地玩家
        if (!isLocalPlayer)
        {
            return;
        }
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        //得到运动的方向
        Vector3 dir = hor * transform.right + ver * transform.forward;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        else
        {
            speed = 3;
        }        
        motor.Move(dir.normalized * speed);
	}
}
