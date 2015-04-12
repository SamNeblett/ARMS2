using UnityEngine;
using System.Collections;

public class ResourcesController : MonoBehaviour {

	public GUITexture OxygenBar, Co2Bar, PressureBar, PowerBar;

	public GUIText OxygenText, Co2Text, PressureText, PowerText, TempText;

	float OxygenLevel, Co2Level, PressureLevel, PowerLevel, Temperature;

	void Start () 
	{
		OxygenLevel = 100.0f;
		Co2Level = 0.02f;
		PressureLevel = .401f;
		PowerLevel = 100.0f;
		Temperature = 22.3f;

		StartCoroutine(OxygenLevelAnimator());

		StartCoroutine(Co2LevelAnimator());
	}

	IEnumerator OxygenLevelAnimator()
	{
		yield return new WaitForSeconds(3.0f);
		OxygenLevel-= 0.1f;

		StartCoroutine(OxygenLevelAnimator());
	}

	IEnumerator Co2LevelAnimator()
	{
		yield return new WaitForSeconds(1.5f);
		Co2Level += 0.01f;



		StartCoroutine(Co2LevelAnimator());
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(OxygenLevel.ToString().Length < 5)
		{
			OxygenText.text = OxygenLevel.ToString() + "%";
		} else {
			string os = OxygenLevel.ToString().Substring(0, 5);
			OxygenText.text = os + "%";
		}

		if(Co2Level.ToString().Length < 5)
		{
			Co2Text.text = Co2Level.ToString() + "%";
		} else {
			string o2 = Co2Level.ToString().Substring(0, 5);
			Co2Text.text = o2 + "%";
		}


	}
}
