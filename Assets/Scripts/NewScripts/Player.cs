using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _hp = 20;
    public UnityEngine.UI.Text hpText;
    public int playerHp { 
        get { return _hp; } 
        set 
        {
            _hp = value;
            if (_hp <= 0)
            {
                _hp = 0;
                // enable ragdoll
            }
            hpText.text = _hp.ToString();
        } 
    }

    void Start()
    {
        GameManager.Instance().player = this;
    }
}
