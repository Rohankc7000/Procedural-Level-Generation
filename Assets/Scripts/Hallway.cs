using UnityEngine;

public class Hallway
{
	Vector2Int startPosition;
	Vector2Int endPosition;

	Room startRoom;
	Room endRoom;

	public Room StartRoom { get { return startRoom; } set { startRoom = value; } }
	public Room EndRoom { get { return endRoom; } set { endRoom = value; } }

	public Vector2Int StartPositionAbsolute
	{
		get
		{
			Debug.Log("Start Position: " + startPosition);
			Debug.Log("Start Room Position: " + startRoom.Area.position);
			Debug.Log("StartPositionAbsolute: " + (startPosition + startRoom.Area.position));
			return startPosition + startRoom.Area.position;
		}
	}
	public Vector2Int EndPositionAbsolute
	{
		get
		{
			Debug.Log("End Position: " + endPosition);
			Debug.Log("End Room Position: " + endRoom.Area.position);
			Debug.Log("EndPositionAbsolute: " + (endPosition + endRoom.Area.position));
			return endPosition + endRoom.Area.position;
		}
	}

	public Hallway(Vector2Int startPosition, Room startRoom = null)
	{
		this.startPosition = startPosition;
		this.startRoom = startRoom;
	}
}
