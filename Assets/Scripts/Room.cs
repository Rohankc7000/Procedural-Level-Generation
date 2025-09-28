using System.Collections.Generic;
using UnityEngine;

public class Room
{
	private RectInt area;
	public RectInt Area { get { return area; } }

	public Room(RectInt area)
	{
		this.area = area;
	}

	public List<Hallway> CalculateAllPossibleDoorWays(int width, int length, int minDistanceFromEdge)
	{
		List<Hallway> hallwayCandidate = new List<Hallway>();

		int top = length - 1;
		int minX = minDistanceFromEdge;
		int maxX = width - minDistanceFromEdge;

		for (int i = minX; i < maxX; i++)
		{
			hallwayCandidate.Add(new Hallway(new Vector2Int(i, 0)));
			hallwayCandidate.Add(new Hallway(new Vector2Int(i, top)));
		}

		int right = width - 1;
		int minY = minDistanceFromEdge;
		int maxY = length - minDistanceFromEdge;

		for (int i = minY; i < maxY; i++)
		{
			hallwayCandidate.Add(new Hallway(new Vector2Int(0, i)));
			hallwayCandidate.Add(new Hallway(new Vector2Int(right, i)));
		}
		return hallwayCandidate;
	}
}
