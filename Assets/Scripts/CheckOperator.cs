using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOperator : MonoBehaviour
{
    public static CheckOperator Instance;

    public LineRenderer[] ValidLines;

    public ReactOnTouch GnobPrefab;

    private List<ReactOnTouch> CircuitPositions = new List<ReactOnTouch>();

    private void Awake()
    {
        Instance = this;
        foreach (var line in ValidLines)
        {
            for (var i = 1; i < line.positionCount - 1; i++)
            {
                CircuitPositions.Add(GameObject.Instantiate(GnobPrefab, line.transform.TransformPoint(line.GetPosition(i)), Quaternion.identity, transform));
            }
        }
    }

    public bool CheckPosition(OperatorControl control, out Vector3 pos)
    {
        foreach (var line in ValidLines)
        {
            for (var i = 1; i < line.positionCount - 1; i++)
            {
                pos = line.transform.TransformPoint(line.GetPosition(i));
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
