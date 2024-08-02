using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStates : MonoBehaviour
{
  [SerializeField] public int livesCount;
  public UnityEvent testEvent;

void Start() {
    livesCount = 3;
    testEvent.Invoke();
}
// public void OnCollisionEnter2D(Collision2D collision){
//     // if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
//     //     Debug.Log("collided with enemy");
//     //     liveCountDecrease.AddListener(DecreaseLive);
//     // liveCountDecrease.AddListener(UpdateLivesCount);
//     //     liveCountDecrease.Invoke();
//     // }
    
// }
   public void DecreaseLive() {
    livesCount -= 1;
    Debug.Log("event handled, livescount -1");
   }
}
