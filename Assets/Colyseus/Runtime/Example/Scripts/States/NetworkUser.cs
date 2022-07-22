// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.23
// 

using Colyseus.Schema;

public partial class NetworkUser : Schema {
	[Type(0, "string")]
	public string id = default(string);

	[Type(1, "string")]
	public string sessionId = default(string);

	[Type(2, "boolean")]
	public bool connected = default(bool);

	[Type(3, "number")]
	public float timestamp = default(float);

	[Type(4, "string")]
	public string nick = default(string);

	[Type(5, "string")]
	public string prefabName = default(string);

	[Type(6, "map", typeof(MapSchema<string>), "string")]
	public MapSchema<string> attributes = new MapSchema<string>();
}

