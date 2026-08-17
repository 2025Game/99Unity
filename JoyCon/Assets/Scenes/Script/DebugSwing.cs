using UnityEngine;

public class DebugSwing : MonoBehaviour
{
    public GameObject balance_bar;
    public float velocity = 30.0f; //最大速度
    public float rot_pow = 2.0f;
    public float fwd_pow = 60.0f;

    [Header("回転の設定")]
    [Tooltip("回転の最大角度（度）")]
    public float maxAngle = 15f; // 左右に15度

    [Tooltip("回転のスピード")]
    public float speed = 3.0f;   // 値を大きくすると速く振れます

    private float initialZAngle;

    void Start()
    {
        // 初期状態のZ軸の回転角度を覚えておく
        initialZAngle = transform.eulerAngles.z;
    }

    void Update()
    {
        float rot_z;
        //自身の傾きが少ないほど移動する
        rot_z = transform.eulerAngles.z;
        if (rot_z > 180.0f)
        {
            rot_z -= 360.0f;
        }
        float brake = Mathf.Abs(rot_z);
        speed = velocity - brake;
        if (speed < 0.0f)
            speed = 0.0f;

        speed /= fwd_pow;
        //前進する
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;

        //バランス棒の傾いている方へ傾ける
        //ワールドローテーション
        rot_z = balance_bar.transform.eulerAngles.z;
        if (rot_z > 180.0f)
        {
            rot_z -= 360.0f;
            rot_z -= speed * rot_pow;
        }
        else
        {
            rot_z += speed * rot_pow;
        }
        //transform.Rotate(0.0f, 0.0f,rot_z*Time.deltaTime);

        // Mathf.Sin(Time.time * speed) は -1 から 1 の間を滑らかに往復します
        //float currentAngle = Mathf.Sin(Time.time * speed) * maxAngle;

        // 初期角度に計算した角度を加算してZ軸を回転させる
        //transform.rotation = Quaternion.Euler(0f, 0f, initialZAngle + currentAngle);



    }
}
