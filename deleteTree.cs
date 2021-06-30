using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Block : UdonSharpBehaviour
{
    void Start()
    {
        
    }

    //スクリプト「Block」がアタッチされたオブジェクトが、他のオブジェクトと当たったら実行
    private void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.layer == 24) //当たった相手がレイヤー24のオブジェクトか判定        
　　　　{
            //このスクリプトを実行しているプレイヤーが「オーナ」でなければ「オーナ」にする
            //if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject)) Networking.SetOwner(Networking.LocalPlayer, this.gameObject);

            //同じワールドにいる全プレイヤに「DestroyObject()」を実行させる
　　　　　　 //SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, “DestroyObject”);
　　　　　　 DestroyObject();
        }

    }

    private void DestroyObject()
    {
        //スクリプト「Block」がアタッチされたオブジェクトを消す
        Destroy(this.gameObject, 0.0f); 
    }
}