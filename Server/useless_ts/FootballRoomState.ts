import { Schema, type, MapSchema } from "@colyseus/schema";

export class FootballNetworkedEntity extends Schema {
    @type("string") id: string;
    @type("string") ownerId: string;
    @type("string") creationId: string = "";
    @type("number") xPos: number = 0;
    @type("number") yPos: number = 0;
    @type("number") zPos: number = 0;
    @type("number") xRot: number = 0;
    @type("number") yRot: number = 0;
    @type("number") zRot: number = 0;
    @type("number") wRot: number = 0;
    @type("number") xScale: number = 1;
    @type("number") yScale: number = 1;
    @type("number") zScale: number = 1;
    @type("number") timestamp: number;
    @type("number") xVel: number = 0;
    @type("number") yVel: number = 0;
    @type("number") zVel: number = 0;
    @type({map: "string"}) attributes = new MapSchema<string>();
}

export class FootballNetworkedUser extends Schema {
    @type("string") sessionId: string;
    @type("boolean") connected: boolean;
    @type("number") timestamp: number;
    @type({map: "string"}) attributes = new MapSchema<string>();
}

export class FootballRoomState extends Schema {
    @type({ map: FootballNetworkedEntity }) networkedEntities = new MapSchema<FootballNetworkedEntity>();
    @type({ map: FootballNetworkedUser }) networkedUsers = new MapSchema<FootballNetworkedUser>();
    @type({ map: "string" }) attributes = new MapSchema<string>();
}
