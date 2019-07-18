using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour {
	[SerializeField] protected Transform[] spawnPoints;
	[SerializeField] protected GameObject spawnPrefab;
	[SerializeField] protected int spawnDelay;
	[SerializeField] protected int spawnStartDelay;
	[SerializeField] protected bool toSpawn;

	private Spawnable[] spawnObjects;

	private float frameCounter = 0;
	private int spawnPointIndex = -1; 
	private bool hasStartedSpawning = false;

	private void Awake() {
		Initialize();
	}

	private void Update(){
		if(!toSpawn) return;

		frameCounter += Time.deltaTime;
		if(hasStartedSpawning){
			if(frameCounter > spawnDelay){
				frameCounter = 0;
				Spawn();
			}
		}
		else{
			if(frameCounter > spawnStartDelay){
				frameCounter = 0;
				hasStartedSpawning = true;
				Spawn();
			}
		}
	}

	public void Spawn(){
		spawnPointIndex = Random.Range(0, spawnPoints.Length);
		if(spawnObjects[spawnPointIndex].IsAvailableToSpawn()) spawnObjects[spawnPointIndex].OnSpawn(spawnPoints[spawnPointIndex].transform.position);
	}

	public void Initialize(){
		spawnObjects = new Spawnable[spawnPoints.Length];
		for(int i=0; i<spawnPoints.Length; i++){
			spawnObjects[i] = Instantiate(spawnPrefab, spawnPoints[i].position, Quaternion.identity, transform).GetComponent<Spawnable>();
		} 
	}

	public void Reset(){
		hasStartedSpawning = false;
		frameCounter = 0;
		foreach(Spawnable spawnable in spawnObjects) spawnable.ResetSpawn();
	}

	public bool ToSpawn{
		set{
			toSpawn = value;
			Reset();
		}
	}
}
