using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //’Ç‚¢‚©‚¯‚é‘ÎÛ
    [SerializeField] private Transform target;

    //ƒJƒƒ‰‚ÌˆÚ“®”ÍˆÍ§ŒÀ
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
            if (target != null)
        {
            float x = Mathf.Clamp(target.position.x, minX, maxX);
            float y = Mathf.Clamp(target.position.y, minY, maxY);

            transform.position = new Vector3(x,y,transform.position.z);
        }
        
    }
}