import { Component, OnInit, Input } from '@angular/core';
import { Round } from './shared/Round.model';
import { GameService } from '../NewGame/shared/Game.service';
import { Game } from '../NewGame/shared/Game.model';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
	moduleId: module.id,
	selector: 'Round',
	templateUrl: 'Round.component.html',
	providers: [GameService]
})
export class RoundComponent implements OnInit {
	runningGame: Game = new Game();
	bet: string;
	player: string;

	constructor(private routerNavigation: Router, private route: ActivatedRoute, 
					private service: GameService) 
	{	
	}

	ngOnInit() {
		this.route.queryParams.subscribe(params => {
		
			this.runningGame.id = params['gameId'];
			this.player = params['player'];

			this.service.get(this.runningGame.id)
			.subscribe(res => {
				this.runningGame = res[0] as Game;
  			});
	  
		
	  });
		}
		
		
	choose($event)
	{
		this.bet = $event.srcElement.name;
	}

	next()
	{
		var i = this.runningGame.rounds.length;
		if(this.player === this.runningGame.playerTwoName)
		{
			this.runningGame.rounds[i-1].playerTwoChoice = this.bet;
			console.log(this.runningGame.rounds);
			this.nextRound();
		}
		this.runningGame.rounds.push({id:0, playerOneChoice: ""} as Round);				
		this.runningGame.rounds[i].playerOneChoice = this.bet;
		this.player = this.runningGame.playerTwoName;
	
		
	}
	nextRound()
	{
		let destination = this.runningGame.rounds.length == 3? 
		{ 
			route:["scores"], 
			params: { queryParams: { gameId: this.runningGame.id }}
		}:
		{ 
			route:["round"], 
			params: { queryParams: { 
									gameId: this.runningGame.id, 
									 player: this.runningGame.playerOneName,
									 round: this.runningGame.rounds.length+1
									}}
		};

		this.service.executeRound(this.runningGame as Game).subscribe(res => 
		{
			console.log(res);
			
			this.routerNavigation.navigate(destination.route, destination.params);
		});
	}
	
	
}