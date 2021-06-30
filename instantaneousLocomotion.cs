using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerCollider : UdonSharpBehaviour
{
    //private int PlayerHP = 1;
    private VRCPlayerApi PlayerLocal; //プレイヤの位置を取得するために使用
    public GameObject ReSpawn; //プレイヤのワープ先に置くオブジェクト

    private Vector3 PlayerPos; //プレイヤの位置を格納する変数

    void Start()
    {
        PlayerLocal = Networking.LocalPlayer; //プレイヤ情報を取得
    }

    private void Update()
    {
        //プレイヤの位置を取得
        PlayerPos = PlayerLocal.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position;
       
        //このスクリプトがアタッチされているオブジェクトを、プレイヤの位置に移動
        //this.transform.position = PlayerPos;

        //if (PlayerHP <= 0)
        //{
        //    TeleportPlayer();
        //}
    }

    //プレイヤをワープさせる関数
    private void TeleportPlayer()
    {
        //プレイヤをワープさせる。位置と方向は「ReSpawn」に合わせる。
        PlayerLocal.TeleportTo(ReSpawn.transform.position, ReSpawn.transform.rotation);

        //PlayerHP = 1; //プレイヤのHPを回復
    }

    //他のオブジェクトと衝突したか判定
    //private void OnTriggerEnter(Collider col)
    //{
    //    //レイヤ23のオブジェクトと衝突したかどうかを判定
    //    if (col.gameObject.layer == 23) 
    //    {
    //        PlayerHP -= 1; //プレイヤのHPを減らす
    //    }
    //}
    
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player != Networking.LocalPlayer) return; //LocalPlayer以外はスルー
        Debug.Log("OnPlayerTriggerEnter() : " + player.displayName);
        // ここに何かしらの処理
        TeleportPlayer();
    }
}