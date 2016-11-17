using UnityEngine;
using System.Collections;

public static class Direction {

	// Fixed directions of player travel (based on the angle ratios we're using for the map)
	public const float N = 0.663225f,
	NE = 0.331613f,
	E = 0.0f,
	SE = 0.663225f + Mathf.PI + 0.331613f,
	S = 0.663225f + Mathf.PI,
	SW = 0.663225f + Mathf.PI - 0.331613f,
	W = Mathf.PI,
	NW = 0.663225f + 0.331613f;
}
