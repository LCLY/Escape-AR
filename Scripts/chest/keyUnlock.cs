using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyUnlock : MonoBehaviour
{
    public GameObject key;
    Animator keyAnimation;
    // Start is called before the first frame update
    void Start()
    {
        keyAnimation = key.GetComponent<Animator>();
        key.SetActive(false); //hide
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "keys")
        {
            key.SetActive(true);//show 
            keyAnimation.SetTrigger("keyUnlock");
            Debug.Log("key entered");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
