using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerInGame : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _x, _y;
    private Material _material;

    void Start()
    {
        _material = _spriteRenderer.material;
    }

    void Update()
    {
        _material.mainTextureOffset += new Vector2(_x, _y) * Time.deltaTime;
    }
}
