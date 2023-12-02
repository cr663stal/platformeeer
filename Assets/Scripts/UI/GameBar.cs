using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBar : MonoBehaviour
{
    [SerializeField] Image _hpImage;
    private SystemHpPlayer _systemHpPlayer;
    private float _maxHp;
    private float _currentHp;
    private float _stepHp;

    private void Awake()
    {
        _systemHpPlayer = FindObjectOfType<SystemHpPlayer>();
    }

    private void Start()
    {
        GetParameters();
        GetHpParameters();
    }
    
    private void GetParameters()
    {
        _maxHp = _systemHpPlayer.CheckMaxHp();
        _currentHp = _systemHpPlayer.CheckCurrentHp();
    }
    public void GetHpParameters()
    {
        _currentHp = _systemHpPlayer.CheckCurrentHp();
        _hpImage.fillAmount = _currentHp / _maxHp;
    }

    private void Update()
    {
        GetHpParameters();
    }
}
