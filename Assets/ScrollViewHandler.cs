using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScrollViewHandler : MonoBehaviour {

    public Texture2D textureNums;
    public Texture2D textureLittleNums_red;
    public Texture2D textureLittleNums_green;
    public Texture2D textureAnswerDescription;
    public Texture2D textureEndOfGame;

    RectTransform scrlRectContent;

    int textureNumsWidth;
    int textureNumsHeight;

    int textureLittleNumsWidth;
    int textureLittleNumsHeight;

    int textureAnswerDescriptionWidth;

    int textureResultTableWidth;

    Manager manager;


	// Use this for initialization
	void Start () {

        manager = GameObject.Find("Manager").GetComponent<Manager>();
        scrlRectContent = GameObject.Find("Content").GetComponent<RectTransform>();

        textureNumsHeight = textureNums.height / 10;
        textureNumsWidth = textureNums.width;

        textureLittleNumsHeight = textureLittleNums_red.height / 5;
        textureLittleNumsWidth = textureLittleNums_red.width;

        textureAnswerDescriptionWidth = textureAnswerDescription.width;

        textureResultTableWidth = textureNumsWidth * 4 + textureAnswerDescriptionWidth;

        //Texture2D t = new Texture2D(textureLittleNumsWidth, textureLittleNumsHeight);
        //t.SetPixels(GetLittleNumber(1));
        //t.Apply();
        //GameObject.Find("Image").GetComponent<Image>().sprite = Sprite.Create(t,new Rect(0,0,textureLittleNumsWidth,textureLittleNumsHeight), new Vector2(0,0));
	}

    private Color[] GetNumber(int number)
    {
        return textureNums.GetPixels(0, textureNumsHeight * number, textureNumsWidth, textureNumsHeight);
    }

    private Color[] GetLittleNumber(int number, string color)
    {
        if (color == "green")
            return textureLittleNums_green.GetPixels(0, textureLittleNumsHeight * number, textureLittleNumsWidth, textureLittleNumsHeight);
        return textureLittleNums_red.GetPixels(0, textureLittleNumsHeight * number, textureLittleNumsWidth, textureLittleNumsHeight);
    }

    public void CreateResultTable()
    {
        int endOfGame = 0;
        int countOfRows;
        List<int[]> input = manager.GetResultTable();
        input.Reverse();
        //проверяем что на месте 4 цыфры

        if (input[0][4] == 4) {
            endOfGame = 1;
            input.Insert(0, new int[6]);
        }
        

        countOfRows = input.Count;// + endOfGame;
        int textureResultTableHeight = countOfRows * textureNumsHeight;
        Texture2D textureResultTable = new Texture2D(textureResultTableWidth, textureResultTableHeight);
        //GameObject.Find("Content").GetComponent<Image>();
        //print(textureResultTable.height + " " + textureResultTable.width);
        scrlRectContent.sizeDelta = new Vector2(0, textureResultTable.height);
        //scrlRectContent.localPosition = new Vector3(0, -508, 0);
       // GameObject.Find("Scroll View").GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
        
        //scrlRectContent.position = new Vector3(1, -1, 0);
        for (int row = 0 +endOfGame ; row < countOfRows; row++)
        {
            for (int column = 0; column < 4; column++)
            {
                textureResultTable.SetPixels(column * textureNumsWidth, row * textureNumsHeight, textureNumsWidth, textureNumsHeight, GetNumber(input[row][column]));
            }
            
            //textureResultTable.SetPixels(textureResultTableWidth - textureAnswerDescriptionWidth, row * textureNumsHeight, textureAnswerDescriptionWidth, textureAnswerDescription.height, textureAnswerDescription.GetPixels());
            textureResultTable.SetPixels(textureResultTableWidth - textureAnswerDescriptionWidth, row * textureNumsHeight, textureAnswerDescriptionWidth, textureAnswerDescription.height, textureAnswerDescription.GetPixels());
            //на месте зеленый
            //textureResultTable.SetPixels(4 * textureNumsWidth + 40, row * textureNumsHeight + textureLittleNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight, GetLittleNumber(input[row][4]));
            Color[] tmp = textureResultTable.GetPixels(4 * textureNumsWidth + 40, row * textureNumsHeight + textureLittleNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight);
            Color[] res = textureResultTable.GetPixels(4 * textureNumsWidth + 40, row * textureNumsHeight + textureLittleNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight);
            Color[] answerNumber = GetLittleNumber(input[row][4], "green");
            for (int i = 0; i < tmp.Length; i++)
            {
                res[i] = Color.Lerp(tmp[i], answerNumber[i], answerNumber[i].a);
            }
            textureResultTable.SetPixels(4 * textureNumsWidth + 40, row * textureNumsHeight + textureLittleNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight, res);
            //не на месте красный
            Color[] tmp1 = textureResultTable.GetPixels(4 * textureNumsWidth + 60, row * textureNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight);
            Color[] res1 = textureResultTable.GetPixels(4 * textureNumsWidth + 60, row * textureNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight);
            Color[] answerNumber1 = GetLittleNumber(input[row][5], "red");
            for (int i = 0; i < tmp1.Length; i++)
            {
                res1[i] = Color.Lerp(tmp1[i], answerNumber1[i], answerNumber1[i].a);
            }
            textureResultTable.SetPixels(4 * textureNumsWidth + 60, row * textureNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight, res1);
        }
        if (endOfGame == 1)
        {
            textureResultTable.SetPixels(0, 0 * textureNumsHeight, 384, 62, textureEndOfGame.GetPixels());
            GameObject.Find("Button").GetComponent<CheckButtonHandler>().EndOfGame();
        }

        textureResultTable.Apply();
        GameObject.Find("Content").GetComponent<Image>().sprite = Sprite.Create(textureResultTable, new Rect(0, 0, textureResultTableWidth, textureResultTableHeight), new Vector2(0, 0));

        //GameObject.Find("Scroll View").GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //print(GameObject.Find("Scroll View").GetComponent<ScrollRect>().verticalNormalizedPosition);
    }
}
