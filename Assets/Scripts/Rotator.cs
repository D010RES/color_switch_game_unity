using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;
    private int _reverse;
    [SerializeField]
    private bool isCheck;

    private void Start() {
        if (isCheck == true) {
            _reverse = -1;
        }
        else {
            _reverse = 1;
        }
    }

    void Update() {
        transform.Rotate(0f, 0f, 0.5f * speed * Time.deltaTime * _reverse);
    }
}
