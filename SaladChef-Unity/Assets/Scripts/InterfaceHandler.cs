using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable{
	void OnInteract(PlayerSpawner player);
}

public interface Spawnable{
	bool IsAvailableToSpawn();
	void OnSpawn(Vector2 position);
	void ResetSpawn();
}