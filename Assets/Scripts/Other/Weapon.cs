using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D rbWeapon;
    private bool isWeaponVisible;

    public int idWeapon;
    public float speedWeapon;
    public float forceImpulseWeapon;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        rbWeapon = GetComponent<Rigidbody2D>();
        if(idWeapon==0)
        {
            rbWeapon.velocity = new Vector2(speedWeapon, 0);
        }
        if(idWeapon==1)
        {
            rbWeapon.AddForce(Vector2.one * forceImpulseWeapon, ForceMode2D.Impulse);
            StartCoroutine("explosion");
        }
        //Enemy attack
        if(idWeapon==6)
        {
            rbWeapon.velocity = new Vector2(speedWeapon, 0);
        }
    }

    private void OnBecameVisible() {
        isWeaponVisible = true;
    }

    private void OnBecameInvisible() {
        isWeaponVisible = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag.Equals("damage") && isWeaponVisible && idWeapon==0)
        {
            GameObject temp = Instantiate(_GameController.vFxDestroy[0], other.transform.position, other.transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(_GameController.getSpeed(),0);

            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Destroy(temp.gameObject, 1f);
        }

        if((other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("weapon")) && isWeaponVisible && idWeapon==6)
        {
            GameObject temp = Instantiate(_GameController.vFxDestroy[0], other.transform.position, other.transform.rotation);
            print("ENTORU");
        }
    }

    IEnumerator explosion()
    {
        yield return new WaitForSeconds(0.35f);
        _GameController.SetFx(5);
        Destroy(Instantiate(_GameController.vFxDestroy[1], transform.position, transform.rotation), 0.5f);
        Destroy(this.gameObject);
    }
}
