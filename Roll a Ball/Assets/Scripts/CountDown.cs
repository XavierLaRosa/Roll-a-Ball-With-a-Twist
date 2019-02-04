using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour{

	[SerializeField] private Text uiText;
	[SerializeField] private float mainTimer;

	public float timer;//what will actually be used as a countdown
	private bool canCount = true;
	private bool doOnce = false;

	void Start(){
		timer = mainTimer;
	}

	void Update(){
		if(timer >= 0.0f && canCount){
			timer -= Time.deltaTime;
			uiText.text = timer.ToString("F");//timer is a float conveted to a string 
		}else if(timer <= 0.0f && !doOnce){
			canCount = false;
			doOnce = true;
			uiText.text = "0.00";
			timer = 0.0f;
		}
	}
	public void RestartTimer(){
		canCount = true;
		doOnce = false;
		timer = 120.0f;
		uiText.text = timer.ToString("F");
	}
}