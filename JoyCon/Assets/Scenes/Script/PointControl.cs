using UnityEngine;

public class PointControl : MonoBehaviour
{
    Joycon joycon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joycon = JoyconManager.Instance.j[0];
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q = joycon.GetVector();
        Vector3 pos = new Vector3 (q.x, q.y, q.z);
        gameObject.transform.position = pos.normalized * 3;
    }
}
