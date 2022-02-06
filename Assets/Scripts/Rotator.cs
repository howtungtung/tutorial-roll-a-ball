using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //每一次幀(Frame)都會被呼叫一次
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);//對自己身上的Transform Component呼叫旋轉方法，透過Time.deltaTime去弭平不同幀率上表現誤差
    }
}
