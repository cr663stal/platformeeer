using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTrigger : MonoBehaviour
{
    [SerializeField] float _health = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SystemHpCharacter>())
        {
            other.GetComponent<SystemHpCharacter>().GetHp(_health);
        }
    }
}
