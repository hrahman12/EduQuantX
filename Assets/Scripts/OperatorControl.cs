using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class OperatorControl : MonoBehaviour
{
    private bool _createdClone = false;

    public float MoveSpeed = 5F;

    public ReactOnTouch CurrentPos { get; internal set; }

    private bool _moving = false;
    private Vector3 _startPos;
    private Renderer _renderer;


    public bool IsInPos(Vector3 pos)
    {
        return _renderer.bounds.Contains(pos);
    }

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void CheckIfMovedAway()
    {
        _moving = true;
        _startPos = transform.position;
        if (_createdClone) return;
        StartCoroutine(CheckIfMovedAsync());
    }

    public void CheckPositionAfterMove()
    {
        _moving = false;
        if (CurrentPos && IsInPos(CurrentPos.transform.position))
        {
            Destroy(GetComponent<ObjectManipulator>());
            StartCoroutine(MoveTo(CurrentPos.transform.position));
            CurrentPos.Operator = this;
        }
        else
        {
            StartCoroutine(MoveTo(_startPos, true));
        }
    }

    private IEnumerator MoveTo(Vector3 pos, bool destroyAfterReach = false)
    {
        while (Vector3.Distance(pos, transform.position) > 0.01F)
        {
            transform.position = Vector3.Lerp(transform.position, pos, MoveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        if (destroyAfterReach)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void Update()
    {
        //if (_moving && CheckOperator.Instance.CheckPosition(this, out var pos))
        //{

        //}
    }

    private IEnumerator CheckIfMovedAsync()
    {
        var startPos = transform.position;
        var startRot = transform.rotation;
        var bnds = new Bounds(_renderer.bounds.center, _renderer.bounds.size);
        while (bnds.Intersects(_renderer.bounds))
        {
            yield return new WaitForEndOfFrame();
        }
        GameObject.Instantiate(gameObject, startPos, startRot, transform.parent);
        _createdClone = true;
        _moving = true;
    }

}
