using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    List<int> Task = new List<int>();
    List<int> Answer = new List<int>() { 0, 1, 2, 3 };
    List<int[]> arrayAnswers = new List<int[]>();

    public delegate void MethodContatiner();
    public event MethodContatiner ValueChangedEvent;

    // Use this for initialization
    void Start()
    {
        Task = GenerateTask();
    }

    public void SetCounter(int index, int value)
    {
        Answer[index] = value;
        for (int i = 0; i < 4; i++)
        {
            if (index == i) continue;
            if (Answer[i] == Answer[index]) Answer[i] = 10;
        }
        ValueChangedEvent();
    }

    private List<int> GenerateTask()
    {
        List<int> result = new List<int>();
        int tmp;
        while (result.Count != 4)
        {
            tmp = (int)Random.Range(0, 9);
            
            if (result.IndexOf(tmp) == -1)
            {
                result.Add(tmp);
            }
        }
        //return result;
        return new List<int> { 4, 1, 2, 3 };
    }

    public List<int> GetSelectedNumbers()
    {
        return Answer;
    }

    public List<int> GetTaskNumbers()
    {
        return Task;
    }

    public List<int[]> GetResultTable()
    {
        return arrayAnswers;
    }
    
    public List<int> CheckAnswer()
    {
        
        int inRightPlace = NumbersInRightPlace();
        int inTask = NumbersInTask() - inRightPlace;

        List<int> result = new List<int> { inRightPlace, inTask };
        CollectAnswer(result);
        return result;
    }

    private int NumbersInTask()
    {
        
        int result = 0;
        foreach (int i in Answer)
        {
            if (Task.IndexOf(i) != -1)
            {
                result += 1;
            }
        }
        return result;
    }

    private int NumbersInRightPlace()
    {
        int result = 0;
        for (int i = 0; i < 4; i++)
        {
            if (Answer[i] == Task[i])
            {
                result += 1;
            }
        }
        return result;
    }
    
    private void CollectAnswer(List<int> answers)
    {
        List<int> result = new List<int>();
        result.AddRange(Answer);
        result.AddRange(answers);
        arrayAnswers.Add(result.ToArray());
    }
    // Update is called once per frame
    void Update () {
	
	}
}
