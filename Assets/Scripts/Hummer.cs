using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hummer : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float _maxScaleHummer;
    [SerializeField] private float _minScaleHummer;
    [SerializeField] private float _nowScaleHummer;
    [SerializeField] private float _stepScale;
    [SerializeField] private Transform _bitObject;
    private Vector3 _scaleNowVector;
    private float _currentTime;
    [SerializeField]private float _timerHit = .6f;
    private Vector3 _eulerPosition;
    private float _rotationZNow = 0;
    private bool _bitNow;
    private bool _isBit = true;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _scaleNowVector = new Vector3(_nowScaleHummer, _nowScaleHummer);
        _transform.localScale = _scaleNowVector;
        _eulerPosition = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        
        if (_currentTime == 0)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _bitNow = true;
                _currentTime += .1f;
            }
        }
        else if (_currentTime > _timerHit)
        {
            _bitNow = false;
            _rotationZNow = 0;
            _currentTime = 0;
            BeatHummer();
            _isBit = true;

        }
        else
        {
            _rotationZNow += (Time.deltaTime * 180)/ _timerHit;
            _currentTime += Time.deltaTime;
        }
        if (_bitNow)
        {
            BeatHummer();
        }
    }

    private void BeatHummer()
    {
        if (_isBit)
        {
            RaycastHit2D hit = Physics2D.Raycast(_bitObject.position, _bitObject.position.normalized, 1);
            if(hit.collider != null)
            {

                HitOnTheObject();
                _isBit = false;
            }

        }
        _eulerPosition = new Vector3(0, 0, _rotationZNow);
        _transform.rotation = Quaternion.Euler(_eulerPosition);
    }

    private void HitOnTheObject(/*GameObject listener*/)
    {
        MinusVectorScale();
    }

    private void PlusVectorScale()
    {
        _scaleNowVector.x += _stepScale;
        _scaleNowVector.y += _stepScale;
        SetVectorScale();
    }

    private void MinusVectorScale()
    {
        _scaleNowVector.x -= _stepScale;
        _scaleNowVector.y -= _stepScale;
        SetVectorScale();
    }

    private void ResetVectorScale()
    {
        _scaleNowVector.x = _maxScaleHummer;
        _scaleNowVector.y = _maxScaleHummer;
        SetVectorScale();
    }

    private void SetVectorScale()
    {
        _transform.localScale = _scaleNowVector;
    }
}
