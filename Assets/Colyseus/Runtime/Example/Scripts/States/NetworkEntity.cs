// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.23
// 

using Colyseus.Schema;

public partial class NetworkEntity : Schema {
	[Type(0, "string")]
	public string id = default(string);

	[Type(1, "string")]
	public string ownerId = default(string);

	[Type(2, "string")]
	public string creationId = default(string);

	[Type(3, "number")]
	public float xPos = default(float);

	[Type(4, "number")]
	public float yPos = default(float);

	[Type(5, "number")]
	public float zPos = default(float);

	[Type(6, "number")]
	public float yRot = default(float);

	[Type(7, "number")]
	public float timestamp = default(float);

	[Type(8, "map", typeof(MapSchema<string>), "string")]
	public MapSchema<string> attributes = new MapSchema<string>();
}

