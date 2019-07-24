using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingIndicator : MonoBehaviour {

	[SerializeField] private int rotateSpeed = 30;

	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);	
	}
}
