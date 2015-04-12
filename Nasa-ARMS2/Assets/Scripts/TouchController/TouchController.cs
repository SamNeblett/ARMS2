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

	public GUIText LeftSection, CurrentSection, RightSection;

	public TaskManager TM;

	public bool isMoverio = false;

	void Start () 
	{
		if(Application.isEditor || Application.isWebPlayer || isMoverio)
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

	void DoMoveLeft(float currentXPos, GameObject Section)
	{
		if(currentXPos + 1.0f < 2.0f)
		{
			currentXPos += 1.0f;
			
			iTween.MoveTo(Section, iTween.Hash("x", currentXPos, "time", 0.25f, "islocal", true));
			
		} else {
			currentXPos = -1.0f;
			
			Section.transform.localPosition = new Vector3(currentXPos, 0.0f, 0.0f);
			
			
		}

		if(Section.Equals(TaskContainer))
		{
			TasksXPos = currentXPos;

			if(Mathf.Approximately(TasksXPos, 0.0f))
			{
				LeftSection.text = "RESOURCES";
				CurrentSection.text = "TASK";
				RightSection.text = "DIAGRAMS";
			}
		}
		
		if(Section.Equals(ResourcesContainer))
		{
			ResourcesXPos = currentXPos;

			if(Mathf.Approximately(ResourcesXPos, 0.0f))
			{
				CurrentSection.text = "RESOURCES";
				RightSection.text = "TASK";
				LeftSection.text = "DIAGRAMS";
			}
		}

		if(Section.Equals(DiagramsContainer))
		{
			DiagramsXPos = currentXPos;

			if(Mathf.Approximately(DiagramsXPos, 0.0f))
			{
				RightSection.text = "RESOURCES";
				LeftSection.text = "TASK";
				CurrentSection.text = "DIAGRAMS";
			}

		}
	}

	void DoMoveRight(float currentXPos, GameObject Section)
	{


		if(currentXPos - 1.0f > -2.0f)
		{
			currentXPos -= 1.0f;
			
			iTween.MoveTo(Section, iTween.Hash("x", currentXPos, "time", 0.25f, "islocal", true));
			
		} else {
			currentXPos = 1.0f;
			
			Section.transform.localPosition = new Vector3(currentXPos, 0.0f, 0.0f);
			
			
		}

		if(Section.Equals(TaskContainer))
		{
			TasksXPos = currentXPos;

			if(Mathf.Approximately(TasksXPos, 0.0f))
			{
				LeftSection.text = "RESOURCES";
				CurrentSection.text = "TASK";
				RightSection.text = "DIAGRAMS";
			}
		}

		if(Section.Equals(ResourcesContainer))
		{
			ResourcesXPos = currentXPos;

			if(Mathf.Approximately(ResourcesXPos, 0.0f))
			{
				CurrentSection.text = "RESOURCES";
				RightSection.text = "TASK";
				LeftSection.text = "DIAGRAMS";
			}
		}

		if(Section.Equals(DiagramsContainer))
		{
			DiagramsXPos = currentXPos;

			if(Mathf.Approximately(DiagramsXPos, 0.0f))
			{
				RightSection.text = "RESOURCES";
				LeftSection.text = "TASK";
				CurrentSection.text = "DIAGRAMS";
			}
		}
	}

	bool TapLock = false;

	int taplockDelay = 20;

	void MobileUpdate()
	{
		if(Input.touchCount > 0 && !TapLock)
		{

			TapLock = true;

			if(Input.touches[0].position.x < leftXMax)
			{
				DoMoveLeft(TasksXPos, TaskContainer);
				DoMoveLeft(ResourcesXPos, ResourcesContainer);
				DoMoveLeft(DiagramsXPos, DiagramsContainer);

			} else if(Input.touches[0].position.x > leftXMax && Input.touches[0].position.x < rightXMin)
			{

				TM.Advance();

			} else if(Input.touches[0].position.x > rightXMin)
			{
				DoMoveRight(TasksXPos, TaskContainer);
				DoMoveRight(ResourcesXPos, ResourcesContainer);
				DoMoveRight(DiagramsXPos, DiagramsContainer);
			}
		} 

		if(TapLock && Input.touchCount.Equals(0))
		{
			if(taplockDelay - 1 > -1)
			{
				taplockDelay--;
			} else {
				TapLock = false;
				taplockDelay = 20;
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
				TM.Advance();

			} else {

				Debug.Log("RIGHT BUTTON PRESS!");

				DoMoveRight(TasksXPos, TaskContainer);
				DoMoveRight(ResourcesXPos, ResourcesContainer);
				DoMoveRight(DiagramsXPos, DiagramsContainer);
			}
		}
	}
	
}
