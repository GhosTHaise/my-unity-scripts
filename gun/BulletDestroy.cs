 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter(){
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }  
}
