using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFollow : MonoBehaviour
{
    public Transform ObjToFollow;

    public float MinDistAngle = 30F;

    private bool _adjusting = false;

    public float AdjustSpeed = 10F;

    // Update is called once per frame
    void Update()
    {
        var angle = Quaternion.Angle(transform.rotation, ObjToFollow.transform.rotation);
        if (angle > MinDistAngle && !_adjusting)
        {
            StartCoroutine(AdjustRotation(ObjToFollow.transform.rotation));
        }
    }

    private IEnumerator AdjustRotation(Quaternion rotation)
    {
        _adjusting = true;
        while (Quaternion.Angle(rotation, transform.rotation) > 5F)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, AdjustSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        _adjusting = false;
    }
}
