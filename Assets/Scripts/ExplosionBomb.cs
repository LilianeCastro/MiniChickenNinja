using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("damage"))
        {
            Destroy(other.gameObject);
        }
    }
}
