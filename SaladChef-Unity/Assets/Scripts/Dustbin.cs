using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustbin : MonoBehaviour, Interactable {

	public void OnInteract(PlayerSpawner player){
		if(player.ThrowInDustbin()){
			player.IncrementScore(Constants.ANGRY_CUSTOMER_PENALTY);
		}
	}
}
