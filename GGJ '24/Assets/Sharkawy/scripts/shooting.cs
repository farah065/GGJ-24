using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed;
    public bool coolDown = false;
    public Transform player;

    public GameObject canvas;
    PauseMenu PauseMenu;

    private void Start()
    {
        PauseMenu = canvas.GetComponent<PauseMenu>();
    }

    void Update()
    {
        firePoint.position = player.position;
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(transform.position.x, transform.position.y);
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (Input.GetKey(KeyCode.Mouse0) && !coolDown && !PauseMenu.isPaused)
        {
            coolDown = true;
            GameObject ball = Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, lookAngle));
            ball.GetComponent<Rigidbody2D>().velocity = firePoint.right*bulletSpeed;
            StartCoroutine(Cool());
        }
    }

    IEnumerator Cool()
    {
        yield return new WaitForSeconds(0.5f);
        coolDown =false;
    }
}
