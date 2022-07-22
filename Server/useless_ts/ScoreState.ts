import { Schema, type } from "@colyseus/schema";

export class ScoreState extends Schema {
    @type("number") myScore: number;
    @type("number") rivalScore: number;

}