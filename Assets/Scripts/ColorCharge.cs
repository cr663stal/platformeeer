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
    public void ChangeSprite()
    {
        _sprite.color = _aquablue;
    }
    public void ResetSprite()
    {
        _sprite.color = Color.white;
    }
    
}
