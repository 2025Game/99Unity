using UnityEngine;

public class RotationDisplay : MonoBehaviour
{
    public float rx, ry, rz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = transform.rotation.eulerAngles;
        rx = r.x;
        ry = r.y;
        rz = r.z;
    }
}
