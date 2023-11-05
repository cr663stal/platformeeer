using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCharge : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Color _aquablue = new Color(0.49f, 0.99f, 0.99f, 1.0f);

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void ChangeSprite()
    {
        _sprite.color = _aquablue;
    }

    private void ResetSprite()
    {
        _sprite.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeSprite();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetSprite();
        }
    }
}
