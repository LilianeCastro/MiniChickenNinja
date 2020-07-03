using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D rbWeapon;
    private bool isWeaponVisible;

    public float speedWeapon;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        rbWeapon = GetComponent<Rigidbody2D>();
        rbWeapon.velocity = new Vector2(speedWeapon, 0);
    }

    private void OnBecameVisible() {
        isWeaponVisible = true;
    }

    private void OnBecameInvisible() {
        isWeaponVisible = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("damage") && isWeaponVisible)
        {
            GameObject temp = Instantiate(_GameController.vFxDestroy[0], other.transform.position, other.transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(_GameController.getSpeed(),0);

            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Destroy(temp.gameObject, 1f);
        }
    }
}
