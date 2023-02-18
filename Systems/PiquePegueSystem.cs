using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiquePegueSystem : MonoBehaviour
{
    public GameObject[] players;
    private int pegadorIndex;

    void Start(){
        players = GameObject.FindGameObjectsWithTag("Player");
        pegadorIndex = Random.Range(0, players.Length);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.L)){
            Debug.LogWarning("Escolhendo jogador!");
            for (int i = 0; i < players.Length; i++){
                if (i == pegadorIndex){
                    players[i].tag = "Caught";
                    Debug.LogWarning("Você foi o escolhido!");
                }
                else{
                    players[i].tag = "Player";
                    Debug.LogWarning("Você não foi o escolhido!");
                }
            }
        }
    }
}
