using System;
using System.ComponentModel;
using UnityEngine;

public class LayoutGeneratorRooms : MonoBehaviour
{
	[SerializeField] private int width = 64;
	[SerializeField] private int length = 64;

	[SerializeField] private int roomWidthMin = 3;
	[SerializeField] private int roomWidthMax = 5;
	[SerializeField] private int roomLengthMin = 3;
	[SerializeField] private int roomLengthMax = 5;

	[SerializeField] private GameObject levelLayoutDisplay;

	System.Random random;

	[ContextMenu("Generate Level Layout")]
	private void GenerateLevel()
	{
		random = new System.Random();
		var roomRect = GetStartRoomRect();
		Debug.Log(roomRect);
		DrawLayout(roomRect);
	}

	private RectInt GetStartRoomRect()
	{
		int roomWidth = random.Next(roomWidthMin, roomWidthMax);
		int availabelWidthX = width / 2 - roomWidth;
		int randomX = random.Next(0, availabelWidthX);
		int roomX = randomX + (width / 4);

		int roomLength = random.Next(roomLengthMin, roomLengthMax);
		int availableLengthY = length / 2 - roomLength;
		int randomY = random.Next(0, availableLengthY);
		int roomY = randomY + (width / 4);

		return new RectInt(roomX, roomY, roomWidth, roomLength);
	}


	private void DrawLayout(RectInt roomCanditateRect = new RectInt())
	{
		var renderer = levelLayoutDisplay.GetComponent<Renderer>();

		var layoutTexture = (Texture2D)renderer.sharedMaterial.mainTexture;

		layoutTexture.Reinitialize(width, length);
		levelLayoutDisplay.transform.localScale = new Vector3(width, length, 1);
		layoutTexture.FillWithColor(Color.black);
		layoutTexture.DrawRectangle(roomCanditateRect,Color.cyan);
		layoutTexture.SaveAsset();
	}
}
