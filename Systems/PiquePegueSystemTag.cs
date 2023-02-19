using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class PiquePegueSystemTag : NetworkBehaviour
{
    private string _playerTag = "Player";
    public GameObject canvas;
    private bool youAreTheCaught;


    void Start(){
        youAreTheCaught = false;
    }

    void Update(){
        if(youAreTheCaught == true){
            canvas.gameObject.SetActive(true);
        } else {
            canvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == _playerTag && !isLocalPlayer && youAreTheCaught == true)
        {
            youAreTheCaught = false;
        }

        if (_col.gameObject.tag == _playerTag && !isLocalPlayer && youAreTheCaught == false)
        {
            youAreTheCaught = true;
        }
    }
}
