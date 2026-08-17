using UnityEngine;

public class BalanceBar : MonoBehaviour
{
    JoyControl joyControl = null;

    [Header("回転の設定")]
    [Tooltip("回転のスピード")]
    public float rotation_speed = 30.0f;
    public GameObject game_object;
    public Vector3 world_rotation;
    //public float wrx, wry, wrz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joyControl = JoyControl.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(joyControl == null)
        {
            joyControl = JoyControl.Instance;
            return;
        }
        // 左矢印キーが押された瞬間
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // ローカル座標系のZ軸を中心に反時計回り（正の方向）に回転
            // 第2引数に Space.Self を指定するのがポイントです
//            transform.Rotate(0f, 0f, rotation_speed * Time.deltaTime, Space.Self);
        }

        // 右矢印キーが押された瞬間
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // ローカル座標系のZ軸を中心に反時計回り（正の方向）に回転
            // 第2引数に Space.Self を指定するのがポイントです
//            transform.Rotate(0f, 0f, -rotation_speed * Time.deltaTime, Space.Self);
        }

        //ワールドローテーション
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, joyControl.angles.z);
        world_rotation = game_object.transform.rotation.eulerAngles;
    }
}
