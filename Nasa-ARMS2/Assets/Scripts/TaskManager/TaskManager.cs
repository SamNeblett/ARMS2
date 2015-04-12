using UnityEngine;
using System.Collections;

public class TaskManager : MonoBehaviour 
{

	public TaskObject[] Tasks;

	public string[] TaskTexts;

	int start, second, third = 0;

	// Use this for initialization
	void Start () 
	{
		second = 1;
		third = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Advance()
	{
		if(start + 1 < TaskTexts.Length)
		{
			start++;
		} else {
			start = 0;
		}

		if(second + 1 < TaskTexts.Length)
		{
			second++;
		} else {
			second = 0;
		}

		if(third + 1 < TaskTexts.Length)
		{
			third++;
		} else {
			third = 0;
		}

		Tasks[0].StepNumber.text = (start + 1).ToString();
		Tasks[1].StepNumber.text = (second + 1).ToString();
		Tasks[2].StepNumber.text = (third + 1).ToString();

		Tasks[0].StepText.text = TaskTexts[start];
		Tasks[1].StepText.text = TaskTexts[second];
		Tasks[2].StepText.text = TaskTexts[third];
	}


}
