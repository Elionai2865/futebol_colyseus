// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.23
// 

using Colyseus.Schema;

public partial class State : Schema {
	[Type(0, "map", typeof(MapSchema<NetworkEntity>))]
	public MapSchema<NetworkEntity> entities = new MapSchema<NetworkEntity>();

	[Type(1, "map", typeof(MapSchema<NetworkUser>))]
	public MapSchema<NetworkUser> users = new MapSchema<NetworkUser>();

	[Type(2, "map", typeof(MapSchema<string>), "string")]
	public MapSchema<string> attributes = new MapSchema<string>();
}

