using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOperator : MonoBehaviour
{
    public static CheckOperator Instance;

    public LineRenderer[] ValidLines;

    private void Awake()
    {
        Instance = this;
    }

    public bool CheckPosition(OperatorControl control, out Vector3 pos)
    {
        foreach (var line in ValidLines)
        {
            for (var i = 1; i < line.positionCount - 1; i++)
            {
                pos = line.transform.TransformPoint(line.GetPosition(i));
                //Debug.DrawLine(pos, control.transform.position, Color.blue);
                if (control.IsInPos(pos))
                {
                    return true;
                }
            }
        }
        pos = Vector3.zero;
        return false;
    }

}
