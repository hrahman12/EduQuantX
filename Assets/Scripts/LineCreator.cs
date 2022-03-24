using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public LineRenderer LinePrefab;

    public float StartingAngle = 30f;
    public float EndingAngle = 150f;
    public float AngleSteps = 10f;
    public float HeightSteps = -0.1f;

    public float[] Radius;

    private List<LineRenderer> _linesCreated;

    // Start is called before the first frame update
    void Start()
    {
        DestroyOldLines();
        Array.Sort(Radius);
        var lineCnt = 0;
        _linesCreated = new List<LineRenderer>();
        foreach (var val in Radius)
        {
            var line = GameObject.Instantiate(LinePrefab, transform);
            _linesCreated.Add(line);
            var pos = new List<Vector3>();
            var lineHeight = HeightSteps * lineCnt++;
            for (var angle = StartingAngle; angle <= EndingAngle; angle += AngleSteps)
            {
                pos.Add(new Vector3(Mathf.Sin(angle / 180F * Mathf.PI) * val, lineHeight, Mathf.Cos(angle / 180F * Mathf.PI) * val));
            }
            line.positionCount = pos.Count;
            line.SetPositions(pos.ToArray());
        }
    }

    private void DestroyOldLines()
    {
        if (_linesCreated != null)
        {
            foreach (var line in _linesCreated) { Destroy(line.gameObject); }
        }
    }

    private void OnDisable()
    {
        DestroyOldLines();
    }

    private void OnDestroy()
    {
        DestroyOldLines();
    }

}
