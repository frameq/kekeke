using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScrollViewHandler : MonoBehaviour {

    public Texture2D textureNums;
    public Texture2D textureLittleNums;
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

        textureLittleNumsHeight = textureLittleNums.height / 5;
        textureLittleNumsWidth = textureLittleNums.width;

        textureAnswerDescriptionWidth = textureAnswerDescription.width;

        textureResultTableWidth = textureNumsWidth * 4 + textureLittleNumsWidth + textureAnswerDescriptionWidth;

        Texture2D t = new Texture2D(textureLittleNumsWidth, textureLittleNumsHeight);
        t.SetPixels(GetLittleNumber(1));
        t.Apply();
        //GameObject.Find("Image").GetComponent<Image>().sprite = Sprite.Create(t,new Rect(0,0,textureLittleNumsWidth,textureLittleNumsHeight), new Vector2(0,0));
	}

    private Color[] GetNumber(int number)
    {
        return textureNums.GetPixels(0, textureNumsHeight * number, textureNumsWidth, textureNumsHeight);
    }

    private Color[] GetLittleNumber(int number)
    {
        return textureLittleNums.GetPixels(0, textureLittleNumsHeight * number, textureLittleNumsWidth, textureLittleNumsHeight);
    }

    public void CreateResultTable()
    {
        int endOfGame = 0;
        int countOfRows;
        List<int[]> input = manager.GetResultTable();
        //проверяем что на месте 4 цыфры
        
        if (input[input.Count - 1][4] == 4) endOfGame = 1;

        countOfRows = input.Count + endOfGame;
        int textureResultTableHeight = countOfRows * textureNumsHeight;
        Texture2D textureResultTable = new Texture2D(textureResultTableWidth, textureResultTableHeight);
        //GameObject.Find("Content").GetComponent<Image>();
        //print(textureResultTable.height + " " + textureResultTable.width);
        scrlRectContent.sizeDelta = new Vector2(0, textureResultTable.height);
        //scrlRectContent.position = new Vector3(1, -1, 0);
        for (int row = 0; row < countOfRows - endOfGame; row++)
        {
            for (int column = 0; column < 4; column++)
            {
                textureResultTable.SetPixels(column * textureNumsWidth, row * textureNumsHeight, textureNumsWidth, textureNumsHeight, GetNumber(input[row][column]));
            }
            //print(input[row][4]);
            textureResultTable.SetPixels(4 * textureNumsWidth, row * textureNumsHeight + textureLittleNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight, GetLittleNumber(input[row][4]));
            //print(input[row][4]);
            textureResultTable.SetPixels(4 * textureNumsWidth, row * textureNumsHeight, textureLittleNumsWidth, textureLittleNumsHeight, GetLittleNumber(input[row][5]));
            textureResultTable.SetPixels(textureResultTableWidth - textureAnswerDescriptionWidth, row * textureNumsHeight, textureAnswerDescriptionWidth, textureAnswerDescription.height, textureAnswerDescription.GetPixels());
            
        }
        if (endOfGame == 1)
        {
            textureResultTable.SetPixels(0, (countOfRows - 1) * textureNumsHeight, 384, 62, textureEndOfGame.GetPixels());
            GameObject.Find("Button").GetComponent<CheckButtonHandler>().EndOfGame();
        }

        textureResultTable.Apply();
        GameObject.Find("Content").GetComponent<Image>().sprite = Sprite.Create(textureResultTable, new Rect(0, 0, textureResultTableWidth, textureResultTableHeight), new Vector2(0, 0));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
