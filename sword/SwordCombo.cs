using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCombo : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 0.8f;
    private float nextFireTime = 1f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 4f;
    
    // Start is called before the first frame update
    void Start()
    {  
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1")){
            anim.SetBool("hit1",false);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2")){
            anim.SetBool("hit2",false);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3")){
            anim.SetBool("hit3",false);
            noOfClicks = 0;
        }
        if((Time.time - lastClickedTime) > maxComboDelay){
              noOfClicks = 0;
        }
        
        if(Time.time > nextFireTime){
            if(Input.GetMouseButtonDown(0)){
                OnClick();
            }
        }
    }
    
    void OnClick(){
        lastClickedTime = Time.time;
        noOfClicks++;
        if(noOfClicks == 1 ){
          anim.SetBool("hit1",true);
        }
        
        noOfClicks = Mathf.Clamp(noOfClicks,0,3);
        
        if(noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1")){
            anim.SetBool("hit1",false);
            anim.SetBool("hit2", true);
        }
        if(noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2")){
            anim.SetBool("hit2",false);
            anim.SetBool("hit3", true);
        }
    }
}
