using System;
using System.Collections.Generic;
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

	[SerializeField] private List<Hallway> openDoorways;

	System.Random random;

	[ContextMenu("Generate Level Layout")]
	private void GenerateLevel()
	{
		random = new System.Random();
		var roomRect = GetStartRoomRect();
		Debug.Log(roomRect);

		openDoorways = new List<Hallway>();

		Room room = new Room(roomRect);
		List<Hallway> hallways = room.CalculateAllPossibleDoorWays(room.Area.width, room.Area.height, 1);
		//foreach (Hallway h in hallways)
		//{
		//	h.StartRoom = room;
		//}

		//using the lamda experssion
		hallways.ForEach((h) => h.StartRoom = room);
		hallways.ForEach((h) => openDoorways.Add(h));

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
		layoutTexture.DrawRectangle(roomCanditateRect, Color.cyan);

		openDoorways.ForEach((h) => layoutTexture.SetPixel(h.StartPositionAbsolute.x, h.StartPositionAbsolute.y, Color.red));

		layoutTexture.SaveAsset();
	}
}
