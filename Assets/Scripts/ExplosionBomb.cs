using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBomb : MonoBehaviour
{
    private CameraShaker _cameraShaker;

    private void Start() {
        _cameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;
        StartCoroutine(_cameraShaker.shake(.1f, .2f));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("damage"))
        {
            Destroy(other.gameObject);
        }
    }
}
