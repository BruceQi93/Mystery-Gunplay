/************************
 * Title:
 * Function：
 * 	－ 墙上的弹痕
 * Used By：	MachinegunBullet
 * Author:	qwt
 * Date:	
 * Version:	1.0
 * Description:
 *
************************/

using UnityEngine;
using System.Collections;

public class BulletHole : MonoBehaviour {

    //子弹飞行的最大距离
    public float range = 100f;
    //对子弹施加的力
    public float force = 100f;
    //子弹的伤害值
    public float damage = 10f;
    //子弹撞击产生火花的时间
    public float sparkTime = 0.5f;

    public GameObject impactPrefab;
    public GameObject dustPrefab;
    public GameObject sparkPrefab;
    public GameObject debrisPrefab;

    private Transform m_Transform;
    protected Renderer m_Renderer;
    protected bool m_Initialized = false;

    void Awake()
    {
        m_Transform = transform;
        m_Renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        m_Initialized = true;
        DoHit();
    }

    void OnEnable()
    {
        if (!m_Initialized)
        {
            return;
        }
        DoHit();
    }

    //在碰撞到物体上生成弹洞
    private void DoHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = new Ray(m_Transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,range,LayerMask.GetMask("env")))
        {             
            Vector3 scale = m_Transform.localScale;
            m_Transform.parent = hit.transform;
            m_Transform.localPosition = hit.transform.InverseTransformPoint(hit.point);
            m_Transform.rotation = Quaternion.LookRotation(hit.normal);//面对远离碰撞点表面的方向
            if (hit.transform.lossyScale==Vector3.one)
            {
                m_Transform.Rotate(Vector3.forward, Random.Range(0, 360), Space.Self);
            }
            else
            {
                m_Transform.parent = null;
                m_Transform.localScale = scale;
                m_Transform.parent = hit.transform;
            }
            //如果碰撞到的物体有刚体，给子弹添加一个力
            Rigidbody rd = hit.collider.attachedRigidbody;
            if (rd!=null && !rd.isKinematic)
            {
                rd.AddForceAtPosition((ray.direction * force) / Time.timeScale, hit.point);
            }
            //生成撞击特效
            if (impactPrefab!=null)
            {
                Instantiate(impactPrefab, m_Transform.position, m_Transform.rotation);
            }
            //生成灰尘特效
            if (dustPrefab!=null)
            {
                Instantiate(dustPrefab, m_Transform.position, m_Transform.rotation);
            }
            //生成火花特效
            if (sparkPrefab!=null)
            {
                if (Random.value<sparkTime)
                {
                    Instantiate(sparkPrefab, m_Transform.position, m_Transform.rotation);
                }
            }
            //生成碎片特效
            if (debrisPrefab!=null)
            {
                Instantiate(debrisPrefab, m_Transform.position, m_Transform.rotation);
            }
        }
    }
}
