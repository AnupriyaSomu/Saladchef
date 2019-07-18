using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour, Interactable {

	private string vegetableName;
	private TextMesh vegetableUI;

	private bool beingUsed = false;
	private float choppingFrameCounter = 0;
	private PlayerSpawner player;

	private void Awake() {
		vegetableUI = GetComponentInChildren<TextMesh>();
	}

	private void Update() {
		if(!beingUsed) return;

		choppingFrameCounter += Time.deltaTime;
		if(choppingFrameCounter >= Constants.CHOPPING_BOARD_TIME){
			player.AddChoppedVegetable(vegetableName);	
			vegetableName = null;
			vegetableUI.text = "-";
			choppingFrameCounter = 0;
			SetChopping(false);
		}
	}

	private void SetChopping(bool value){
		beingUsed = value;
		player.IsChopping = value;
	}

	public void OnInteract(PlayerSpawner player){
		if(beingUsed) return;

		if(vegetableName == null){
			vegetableName = player.RemoveVegetable();
			if(vegetableName != null) {
				if(!player.IsChoppingReduntant(vegetableName)){
					vegetableUI.text = vegetableName;
					this.player = player;
					SetChopping(true);
				}
				else{
					vegetableName = null;
					vegetableUI.text = "-";
				}
			}
		}
	}

	public void Reset(){
		vegetableName = null;
		vegetableUI.text = "-";
		beingUsed = false;
		choppingFrameCounter = 0;
	}
}
