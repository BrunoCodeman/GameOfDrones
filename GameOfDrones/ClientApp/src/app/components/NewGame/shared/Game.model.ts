import { Round } from "../../PlayerTurn/shared/Round.model";


export interface Game
{
     Id:number;
     PlayerOneName:string;
     PlayerTwoName:string 
     Rounds:Array<Round>;
     GameWinner:string 
}
