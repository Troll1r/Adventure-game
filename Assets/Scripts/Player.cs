using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Player : MonoBehaviour
{
    public Animator animator;
    public List<Rigidbody> rgElements;
    public List<Collider> colliders;
    public int hp;
    private int _hp = 10;
    public int money;
    public int damage;
    public Text damageText;
    public Text hpText;
    public GameObject PressText;
    void Start()
    {
        _hp = hp;
        hpText.text = "HP:" + _hp.ToString();
        damageText.text = "Damage:" + damage.ToString();
        DisablePhysics();
        GameManager.Instance().player = this;
        PressText.SetActive(false);
    }
    public void Update()
    {
        damageText.text = "Damage:" + damage.ToString();
    }
    public int playerHp { 
        get { return _hp; } 
        set 
        {
            
            _hp = value;
            if (_hp <= 0)
            {
                _hp = 0;
                EnablePhysics();
            }
            if (_hp > 0)
                DisablePhysics();
            hpText.text = "HP: " + _hp.ToString();
            hp = _hp;


        }
    }

    public void EnablePhysics()
    {
        animator.enabled = false;
        for (int i = 0; i < rgElements.Count; i++)
            rgElements[i].isKinematic = false;
        for (int i = 0; i < rgElements.Count; i++)
            colliders[i].enabled = true;
        



    }
    public void DisablePhysics()
    {
        animator.enabled = true;
        for (int i = 0; i < rgElements.Count; i++)
            rgElements[i].isKinematic = true;
        for (int i = 0; i < rgElements.Count; i++)
            colliders[i].enabled = false;

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Turnik")
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {

                damage++;
                
                print("качаюсь");
            }
        PressText.SetActive(true);
            
        }
        else
            PressText.SetActive(false);

    }
}
