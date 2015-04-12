using UnityEngine;
using System.Collections;

public class ResolutionController : MonoBehaviour {

	public GUITexture LeftArrow, RightArrow;

	float textureHeight = 0.0f;

	void Start () 
	{
		textureHeight = Screen.height + (Screen.height * .15f);

		LeftArrow.pixelInset = new Rect(-10.58f, -(textureHeight * 0.5f), 290.0f, textureHeight);
		RightArrow.pixelInset = new Rect(-276.3f, -(textureHeight * 0.5f), 290.0f, textureHeight);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
