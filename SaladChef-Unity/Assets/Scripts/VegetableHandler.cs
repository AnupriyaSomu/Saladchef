using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegetableHandler : MonoBehaviour, Interactable{

	private string vegetableName;

	private void Awake() {
		vegetableName = GetComponentInChildren<Text>().text;
	}

	public void OnInteract(PlayerSpawner player){
		player.AddVegetable(vegetableName);
	}
}
