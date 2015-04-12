using UnityEngine;
using System.Collections;

public enum AppState 
{ 
	MainResources, 
	MainTasks,
	MainDiagrams, 
	ZoomResources, 
	ZoomTasks, 
	ZoomDiagrams 
}

public class TouchController : MonoBehaviour {

	bool isMobile = true;

	float leftXMax, rightXMin;

	public GameObject TaskContainer, ResourcesContainer, DiagramsContainer;

	public AppState CurrentState = AppState.MainTasks;

	public float ResourcesXPos, TasksXPos, DiagramsXPos = 0.0f;

	void Start () 
	{
		if(Application.isEditor)
		{
			isMobile = false;
		}

		ResourcesXPos = -1.0f;
		DiagramsXPos = 1.0f;

		leftXMax = Screen.width * 0.3f;  //384

		rightXMin = Screen.width - leftXMax;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isMobile)
		{

			MobileUpdate();

		} else {

			EditorUpdate();

		}
	}

	void DoMoveLeft(float currentXPos, GameObject currentSection)
	{
		if(currentXPos - 1.0f > -2.0f)
		{
			currentXPos -= 1.0f;

			iTween.MoveTo(currentSection, iTween.Hash("x", currentXPos, "time", 0.5f, "islocal", true));

		} else {
			currentXPos = 1.0f;

			currentSection.transform.localPosition = new Vector3(currentXPos, 0.0f, 0.0f);


		}

		if(currentSection.Equals(TaskContainer))
		{
			TasksXPos = currentXPos;
		}
		
		if(currentSection.Equals(ResourcesContainer))
		{
			ResourcesXPos = currentXPos;
		}

		if(currentSection.Equals(DiagramsContainer))
		{
			DiagramsXPos = currentXPos;
		}
	}

	void DoMoveRight(float currentXPos, GameObject currentSection)
	{
		if(currentXPos + 1.0f < 2.0f)
		{
			currentXPos += 1.0f;
			
			iTween.MoveTo(currentSection, iTween.Hash("x", currentXPos, "time", 0.5f, "islocal", true));
			
		} else {
			currentXPos = -1.0f;
			
			currentSection.transform.localPosition = new Vector3(currentXPos, 0.0f, 0.0f);
			

		}

		if(currentSection.Equals(TaskContainer))
		{
			TasksXPos = currentXPos;
		}

		if(currentSection.Equals(ResourcesContainer))
		{
			ResourcesXPos = currentXPos;
		}

		if(currentSection.Equals(DiagramsContainer))
		{
			DiagramsXPos = currentXPos;
		}
	}

	void MobileUpdate()
	{
		if(Input.touchCount > 0)
		{
			if(Input.touches[0].position.x < leftXMax)
			{
				DoMoveLeft(TasksXPos, TaskContainer);
				DoMoveLeft(ResourcesXPos, ResourcesContainer);
				DoMoveLeft(DiagramsXPos, DiagramsContainer);

			} else if(Input.touches[0].position.x > leftXMax && Input.touches[0].position.x < rightXMin)
			{

				//iTween.MoveTo(TaskContainer, iTween.Hash("x", 0.0f, "time", 1.0f, "islocal", true));

			} else if(Input.touches[0].position.x > rightXMin)
			{
				DoMoveRight(TasksXPos, TaskContainer);
				DoMoveRight(ResourcesXPos, ResourcesContainer);
				DoMoveRight(DiagramsXPos, DiagramsContainer);
			}
		}
	}

	void EditorUpdate()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(Input.mousePosition.x < leftXMax)
			{
				Debug.Log("LEFT BUTTON PRESS!");
				DoMoveLeft(TasksXPos, TaskContainer);
				DoMoveLeft(ResourcesXPos, ResourcesContainer);
				DoMoveLeft(DiagramsXPos, DiagramsContainer);

			} else if(Input.mousePosition.x > leftXMax && Input.mousePosition.x < rightXMin)
			{
				Debug.Log("CENTER BUTTON PRESS!");
				//iTween.MoveTo(ResourcesContainer, iTween.Hash("x", -1.0f, "time", 1.0f, "islocal", true));
				//iTween.MoveTo(TaskContainer, iTween.Hash("x", 0.0f, "time", 1.0f, "islocal", true));
			} else {
				Debug.Log("RIGHT BUTTON PRESS!");
				DoMoveRight(TasksXPos, TaskContainer);
				DoMoveRight(ResourcesXPos, ResourcesContainer);
				DoMoveRight(DiagramsXPos, DiagramsContainer);
			}
		}
	}
	
}
