/************************
 * Title:
 * Function：
 * 	－ 
 * Used By：	GameController
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;

public class GamerController : MonoBehaviour {

    public Texture2D aimCursor;//瞄准镜

    private Vector3 vecPos;//鼠标位置
	
	void Start () {
        //播放背景音乐
        AudioManager.PlayBGM("BGM");
        //隐藏鼠标
        HideCursor();
	}
	
	void Update () {
        //按下ESC唤醒鼠标
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowCursor();
        }
        //按下鼠标左键隐藏鼠标
        if (Input.GetMouseButtonDown(0))
        {
            HideCursor();
        }        
	}

    void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //在屏幕上绘制准星
    void OnGUI()
    {
        vecPos = Input.mousePosition;
        GUI.DrawTexture(new Rect(vecPos.x - aimCursor.width / 2, Screen.height - vecPos.y - aimCursor.height / 2, aimCursor.width, aimCursor.height), aimCursor);
    }
}
