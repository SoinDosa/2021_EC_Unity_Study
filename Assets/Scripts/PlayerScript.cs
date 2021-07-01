using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float playerSpeed = 10f;
    bool hitDelayCheck = true;

    public GameObject bullet;
    bool shootDelayCheck = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);

        if(Input.GetMouseButton(0) && shootDelayCheck)
        {
            StartCoroutine("Shoot");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && hitDelayCheck){
            StartCoroutine("HitCheck");
        }
    }
    IEnumerator HitCheck()
    {
        hitDelayCheck = false;
        GameManager.PlayerHit();
        yield return new WaitForSeconds(1);
        hitDelayCheck = true;
    }

    IEnumerator Shoot()
    {
        shootDelayCheck = false;
        Instantiate(bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        shootDelayCheck = true;
    }
}
