using System;
using UnityEngine;

namespace Script.Background
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer mainSpriteRenderer;
        [SerializeField] private float speed;
        private float _height;
        private Vector3 _startPositon;

        private void Start()
        {
            _startPositon = transform.position;
            _height = mainSpriteRenderer.bounds.size.y;
        }

        private void Update()
        {
            transform.Translate(0, -(speed * Time.deltaTime), 0);
            if (_startPositon.y - _height >= transform.position.y) transform.position = _startPositon;
        }
    }
}