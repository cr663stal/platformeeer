using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemHpCharacter : MonoBehaviour
{
    [SerializeField] private float _maximumHeals;
    [SerializeField] private float _healsNow;
    [SerializeField] private float _resist;
    private bool _regenerationNow;
    private float _regenerationPoint;
    private float _currentTimeRegeneration;
    private float _timeRegeneration;


    private void Awake()
    {
        
    }

    private void Update()
    {
        if (_regenerationNow)
        {
            RegenerationCh();
        }
    }

    public void GetDamage(float damage)
    {
        damage *= _resist;
        float tempHp = _healsNow - damage;
        if (tempHp <= 0)
        {
            DeadCh();
        }
        else
        {
            _healsNow = tempHp;
        }
    }

    public void GetHp(float health)
    {
        float tempHp = _healsNow + health;
        if (tempHp > _maximumHeals)
        {
            _healsNow = _maximumHeals;
        }
        else
        {
            _healsNow = tempHp;
        }
    }

    public void GetRegeneration(float time, float hpPoint)
    {
        if (_regenerationNow)
        {
            _timeRegeneration += time;
            _regenerationPoint = hpPoint; // тут похорошему внедрить интерпол€цию, но пока хз надо это вообще или нет.
        }
        else
        {
            _timeRegeneration = time;
            _regenerationPoint = hpPoint;
            _currentTimeRegeneration = 0;
            _regenerationNow = true;
        }

    }

    private void DeadCh()
    {
        Debug.Log("ѕерсонаж мертв");
    }

    private void RegenerationCh()
    {
        if (_currentTimeRegeneration < _timeRegeneration)
        {
            GetHp(_regenerationPoint * Time.deltaTime);
            _currentTimeRegeneration += Time.deltaTime;
        }
        else
        {
            _regenerationNow = false;
        }
    }

    public float CheckCurrentHp()
    {
        return _healsNow;
    }

    public float CheckMaxHp()
    {
        return _maximumHeals;
    }
}
