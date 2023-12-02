using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerationTrigger : MonoBehaviour
{
    [SerializeField] float _time = 10;
    [SerializeField] float _hpPoint = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SystemHpCharacter>())
        {
            other.GetComponent<SystemHpCharacter>().GetRegeneration(_time, _hpPoint);
        }
    }
}
