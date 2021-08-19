using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float playerSpeed = 10f;
    bool hitDelayCheck = true;

    public GameObject bullet;
    bool shootDelayCheck = true;

    private RaycastHit hitInfo;
    public Camera mainCamera;
    private Ray ray;

    public Transform playerPos;

    Vector3 dir;
    //private RaycastHit 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos.transform.Translate(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);

        if(Input.GetMouseButton(0) && shootDelayCheck)
        {
            StartCoroutine("Shoot");
        }

        LookCursor();
    }

    private void LookCursor()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hitInfo))
        {
            dir = new Vector3(hitInfo.point.x, 1f, hitInfo.point.z);
        }

        transform.LookAt(dir);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && hitDelayCheck){
            StartCoroutine("HitCheck");
            collision.transform.GetComponent<Animator>().SetTrigger("Attack");
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
        Instantiate(bullet, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        shootDelayCheck = true;
    }
}
