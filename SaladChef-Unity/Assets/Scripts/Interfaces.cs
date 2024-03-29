﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable{
	void OnInteract(Player player);
}

public interface ISpawnable{
	bool IsAvailableToSpawn();
	void OnSpawn(Vector2 position);
	void ResetSpawn();
}