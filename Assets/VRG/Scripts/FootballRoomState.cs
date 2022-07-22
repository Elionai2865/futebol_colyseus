// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.31
// 

using Colyseus.Schema;

public partial class FootballRoomState : Schema {
	[Type(0, "map", typeof(MapSchema<FootballNetworkedEntity>))]
	public MapSchema<FootballNetworkedEntity> networkedEntities = new MapSchema<FootballNetworkedEntity>();

	[Type(1, "map", typeof(MapSchema<FootballNetworkedUser>))]
	public MapSchema<FootballNetworkedUser> networkedUsers = new MapSchema<FootballNetworkedUser>();

	[Type(2, "map", typeof(MapSchema<string>), "string")]
	public MapSchema<string> attributes = new MapSchema<string>();
}

