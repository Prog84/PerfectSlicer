using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicerSamples;


public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _stunTime;
    [SerializeField] private float _secondsBetweenSlice;

    private float _elapsedTime = 0;
    private float _currentStun = 0;

    private BzKnife _knife;

    private void Start()
    {
        _knife = _blade.GetComponentInChildren<BzKnife>();        
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_elapsedTime >= _secondsBetweenSlice + _currentStun)
            {
                _elapsedTime = 0;
                _currentStun = 0;

                _knife.BeginNewSlice();

                _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration).SetLoops(2, LoopType.Yoyo);
            }
        }
    }

    public void Stun()
    {
        _currentStun = _stunTime;
    }
}
