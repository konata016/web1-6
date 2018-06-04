using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    GameObject player;

    // Use this for initialization
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        //等速落下
        transform.Translate(0, -0.1f, 0);

        //画面外ならオブジェクトの破棄
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }



        //あたり判定
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;

        float r1 = 0.5f;    //矢半径
        float r2 = 1.0f;    //PL半径

        if (d < r1 + r2)
        {
            //監督
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            // 衝突した場合は矢を消す
            Destroy(gameObject);
        }
    }
}
