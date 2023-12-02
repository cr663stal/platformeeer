using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] float _damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SystemHpCharacter>())
        {
            other.GetComponent<SystemHpCharacter>().GetDamage(_damage);
        }
    }
}
