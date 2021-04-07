using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public List<Rigidbody> rgElements;
    private int _hp = 1;
    public UnityEngine.UI.Text hpText;
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
            hpText.text = _hp.ToString();
        } 
    }

    void Start()
    {
        DisablePhysics();
        GameManager.Instance().player = this;
    }

    public void EnablePhysics()
    {
        animator.enabled = false;
        for (int i = 0; i < rgElements.Count; i++)
            rgElements[i].isKinematic = false;
            
    
    
    }
    public void DisablePhysics()
    {
        animator.enabled = true;
        for (int i = 0; i < rgElements.Count; i++)
            rgElements[i].isKinematic = true;

    }
}
