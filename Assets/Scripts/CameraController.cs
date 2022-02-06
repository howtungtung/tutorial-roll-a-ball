using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;//透過Inspector指定Player物件
    private Vector3 offset;//紀錄初始的位移差

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;//計算當前攝影機與Player物件的位移差，並存放到offset變數中
    }

    //在每次Update之後執行，可確保在所有Update中改變位置之後，再移動攝影機位置
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;//讓攝影機與玩家永遠保持一樣的位移差，製造出追隨的效果
    }
}
