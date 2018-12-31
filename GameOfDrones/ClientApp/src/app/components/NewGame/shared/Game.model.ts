import { Round } from "../../Round/shared/Round.model";


export class Game
{
     id:number;
     playerOneName:string;
     playerTwoName:string 
     rounds:Array<Round> = new Array<Round>();
     gameWinner:string 
}
