using UnityEngine;

public class JoyControl : MonoBehaviour
{
    static JoyControl instance;
    public static JoyControl Instance
    {
        get { return instance; }
    }

    Joycon joycon;
    float adjust = 0.0f;
    Quaternion q;
    bool initialized = false;

    public Vector3 angles;
    [SerializeField] private float angle_pow = 0.1f;
    float rx, ry, rz;
    //public float ax, ay, az;
    public Vector3 accel;
    public float accel_pow = 2.0f;

    private void Awake()
    {
        // 他のスクリプトから JoyControl.Instance でアクセスできるようにする
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joycon = JoyconManager.Instance.j[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (joycon == null)
        {
            joycon = JoyconManager.Instance.j[0];
            return;
        }

        q = joycon.GetVector();

        // 初期姿勢がまだならセットする
        if (!initialized)
        {
            if (adjust == 0.0f)
            {
                adjust = -q.eulerAngles.z;
                Debug.Log("初期姿勢セット: " + adjust);
            }
            else
                initialized = true;
        }
        //Xボタンで水平にリセット
        if (joycon.GetButton(Joycon.Button.DPAD_UP))
        {
            adjust = -q.eulerAngles.z;
        }

        //q = joycon.GetVector();
        angles = q.eulerAngles;
        rx = q.eulerAngles.x;
        ry = q.eulerAngles.y;
        rz = q.eulerAngles.z + adjust;
        angles.z = rz;

        angles = angles * angle_pow;

        //gameObject.transform.localEulerAngles = new Vector3(0, 0, rz);

        // 加速度の取得 (単位: G)
        accel = joycon.GetAccel() * accel_pow;

    }
}
