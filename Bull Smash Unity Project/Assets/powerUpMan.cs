using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpMan : MonoBehaviour
{

    [SerializeField] private int _flyTime;
    private Rigidbody rb;

    [SerializeField] private PowerUpManager _powerUpManager;

    [SerializeField] private GameObject _wings;

    private bool holdingItem;
    private int itemIndex = 0;
    private GameObject overheadItem;
    [SerializeField] private Transform overheadItemPos;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fly")
        {
            holdingItem = true;
            itemIndex = 1;
            other.gameObject.SetActive(false);
            GameObject miniItem = _powerUpManager.indexToOverheadItem(0);
            overheadItem = Instantiate(miniItem, overheadItemPos);
            overheadItem.transform.localScale += new Vector3(-0.35f, -0.35f, -0.35f);
            overheadItem.GetComponent<BoxCollider>().enabled = false;
            Invoke("PowerUpManagerCaller", 10);
        }
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") == -1 && holdingItem == true)
        {
            if (itemIndex == 1)
            {
                itemIndex = 0;
                holdingItem = false;
                Destroy(overheadItem);
                StartCoroutine("Fly", _flyTime);
            }
        }
    }

    IEnumerator Fly(float t)
    {
        _wings.SetActive(true);
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        yield return new WaitForSeconds(t);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        _wings.SetActive(false);
        
    }

    private void PowerUpManagerCaller()
    {
        _powerUpManager.NewPowerUp();
    }
}
