using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//宣告引用，為了可以使用InputSystem相關功能
using TMPro;//引用TextMeshPro這個套件相關功能

public class PlayerController : MonoBehaviour
{
    public float speed = 0;//宣告(Declare)一個類型為Float的公開變數，可透過檢視器(Inspector)修改移動速度
    public TextMeshProUGUI countText;//宣告一個類型為TextMeshProUGUI的公開變數，可透過檢視器指定要關聯的物件
    public GameObject winTextObject;//宣告一個類型為GameObject的公開變數，可透過檢視器指定要關聯的物件

    private Rigidbody rb;//宣告私有變數，用來關聯(Reference)RigidBody Component的記憶體位置(Address)
    private int count;//宣告一個類型為Int的變數，用來紀錄當前碰到的Pickup數量
    private float movementX;//宣告私有變數，用來存放玩家輸入的X方向值
    private float movementY;//宣告私有變數，用來存放玩家輸入的Y方向值

    //物件被生成時會自動被系統呼叫一次
    void Start()
    {
        rb = GetComponent<Rigidbody>();//抓取自身物件上的RigidBody Component的記憶體位置(Address)並關聯(Reference)在rb變數中
        SetCountText();//呼叫該方法
        winTextObject.SetActive(false);//關閉該物件
    }

    //實作(Implement)InputSystem要呼叫的方法(Method)，InputValue為InputSystem呼叫時會傳入的參數型態
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();//InputValue參數類別(Class)提供Get方法去讀取當前玩家X Y方向的輸入值
        movementX = movementVector.x;//從二維向量本地變數讀取X軸方向，並存入movementX變數中
        movementY = movementVector.y;//從二維向量本地變數讀取Y軸方向，並存入movementY變數中
    }

    //將當前Count值，更新至UI上
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();//傳入新的字串給UI顯示
        if(count >= 12)//如果當前累計數量超過12以上，則開啟勝利文字物件
        {
            winTextObject.SetActive(true);//開啟勝利文字物件
        }
    }

    //物理運算之前會被系統自動呼叫，所有物理相關的操作都要寫在這個方法(Method)裡面
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0, movementY);//宣告一個三維向量的本地變數，並把先前紀錄的movementX和movementY傳入進去
        rb.AddForce(movement * speed);//透過rb變數去呼叫身上的RigidBody Component，透過AddForce方法施加一個方向的力讓物體移動，透過乘上speed變數控制施加力的大小
    }

    //當其他觸發器(Trigger)碰到此物件，開方法會被呼叫，並傳入碰到的物件Collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))//如果碰到的Collider遊戲物件Tag為Pickup才做判斷
        {
            other.gameObject.SetActive(false);//關閉碰到的物件
            count = count + 1;//count++; 增加計次
            SetCountText();//更新Count UI文字
        }
    }
}
