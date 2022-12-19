using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCombo : MonoBehaviour
{

    public List<Slash> skill;
    private Animator anim;
    public float cooldownTime = 0.8f;
    private float nextFireTime = 1f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 2f;
    private bool attacking;
    // Start is called before the first frame update
    void Start()
    {  
        skill[0].slashObj.SetActive(false);
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

    IEnumerator SlashAttack(){
        for(int i=0; i < skill.Count;i++){
            yield return new WaitForSeconds(skill[i].delay);
            skill[i].slashObj.SetActive(true);
        }

        yield return new WaitForSeconds(1);
        DisableSlashes();
        attacking = false;

    }

    void DisableSlashes(){
        for(int i=0; i < skill.Count;i++){
            skill[i].slashObj.SetActive(false);
        }
        
    }
    
    void OnClick(){
        lastClickedTime = Time.time;
        noOfClicks++;
        if(noOfClicks == 1 && !attacking ){
            anim.SetBool("hit1",true);
            StartCoroutine(SlashAttack());
        }
        
        noOfClicks = Mathf.Clamp(noOfClicks,0,3);
        
        if(noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1")){
            anim.SetBool("hit1",false);
            anim.SetBool("hit2", true);
        }
        if(noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2")){
            anim.SetBool("hit2",false);
            //Instantiate(skill3,transform.position,transform.rotation);
            anim.SetBool("hit3", true);
        }
    }
}

[System.Serializable]
public class Slash{
        public GameObject slashObj;
        public float delay;
 }
