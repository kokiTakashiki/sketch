using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class instantaneousLocomotionSystem : UdonSharpBehaviour
{
    private VRCPlayerApi PlayerLocal; //プレイヤの位置を取得するために使用
    public GameObject ReSpawn; //プレイヤのワープ先に置くオブジェクト

    void Start()
    {
        PlayerLocal = Networking.LocalPlayer; //プレイヤ情報を取得
    }

    private void Update()
    {
    }

     public override void Interact() {
        TeleportPlayer();
    }

    //プレイヤをワープさせる関数
    private void TeleportPlayer()
    {
        //プレイヤをワープさせる。位置と方向は「ReSpawn」に合わせる。
        PlayerLocal.TeleportTo(ReSpawn.transform.position, ReSpawn.transform.rotation);
    }
    
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player != Networking.LocalPlayer) return; //LocalPlayer以外はスルー
        // ここに何かしらの処理
        TeleportPlayer();
    }
}
