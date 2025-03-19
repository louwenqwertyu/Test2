using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFallow : MonoBehaviour
{
    //位置数据
    public Transform target;
    //平滑因子
    public float smoothing;

    public Vector2 minPostion;
    public Vector2 maxPostion;


    // Start is called before the first frame update
    void Start()
    {
        //GameController.camShake = GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraShake>();

    }

    void LateUpdate()
    {
        if(target!=null)
        {
            //如果相机的位置与人物的位置不同
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPostion.x, maxPostion.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPostion.y, maxPostion.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);//线性差值
            }
        }
    }
    
    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPostion = minPos;
        maxPostion = maxPos;
    }
}
