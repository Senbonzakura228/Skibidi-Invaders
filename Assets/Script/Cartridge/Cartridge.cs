using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float speed;

    public float Cooldown => cooldown;

    private void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0));
    }
}
