import { Component, OnInit } from '@angular/core';

import { Game } from './shared/Game.model';
import { GameService } from './shared/Game.service';
import { Router } from '@angular/router';

@Component({
	moduleId: module.id,
	selector: 'NewGame',
	templateUrl: 'NewGame.component.html',
	providers: [GameService]
})	

export class NewGameComponent implements OnInit {
	actualGame: Game;
	constructor(private gameService: GameService, private router: Router) 
	{
		
	}

	ngOnInit() {
		this.actualGame = new Game();
		// this.GameService.getList().subscribe((res) => {
		// 	this.Games = res;
		// });
	}

	startGame()
	{
		//this.actualGame.Rounds.
		this.gameService.newGame(this.actualGame).subscribe((res) => {
			this.router.navigate(["round"],{ queryParams: { gameId: res.id, player: "One" } });
		 });
		
	}
}