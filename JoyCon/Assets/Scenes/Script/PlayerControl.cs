using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Joycon joycon;
    public float gx, gy, gs = 0, gz;
    public float qex, qey, qez;
    public float x, y, z, ay;
    public Quaternion q;
    float rot_y_init;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joycon = JoyconManager.Instance.j[0];
        //joycon.Recenter();
        q = joycon.GetVector();
        Vector3 ad_y = q.eulerAngles;
        rot_y_init = -ad_y.y;
    }

    // Update is called once per frame
    void Update()
    {
        // GetButtonDown checks if a button has been pressed (not held)
        if (joycon.GetButtonDown(Joycon.Button.SHOULDER_2))
        {
            Debug.Log("Shoulder button 2 pressed");
            // GetStick returns a 2-element vector with x/y joystick components
            //Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}", j.GetStick()[0], j.GetStick()[1]));

            // Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
            joycon.Recenter();
        }

        // Gyro values: x, y, z axis values (in radians per second)
        Vector3 gyro = joycon.GetGyro();
        gx = gyro.x;
        gy = gyro.y;
        gz = gyro.z;
        gs += gy;

        q = joycon.GetVector();
        Vector3 ad_y = q.eulerAngles;
        qex = q.eulerAngles.x; qey = q.eulerAngles.y; qez = q.eulerAngles.z;
        qex = qey = 0;

        float ad_yy = rot_y_init - ad_y.y;
        // 2. X軸を90度（逆向きに90度）回転させる補正用のクォータニオンを作る
        Quaternion x_rot = Quaternion.Euler(90f, 0f, 0f);
        Quaternion y_rot = Quaternion.Euler(0f, 90f, 0f);
        Quaternion ay_rot = Quaternion.Euler(0f, ad_yy = 0, 0f);
        gameObject.transform.localRotation = q * x_rot * ay_rot * y_rot;
        Vector3 degree = gameObject.transform.rotation.eulerAngles;
        x = degree.x;
        y = degree.y;
        z = degree.z;
        ay = ad_y.y - rot_y_init;
    }
}
