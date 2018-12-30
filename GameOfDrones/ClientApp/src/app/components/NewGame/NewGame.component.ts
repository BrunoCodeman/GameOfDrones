import { Component, OnInit } from '@angular/core';

import { Game } from './shared/Game.model';
import { GameService } from './shared/Game.service';

@Component({
	moduleId: module.id,
	selector: 'NewGame',
	templateUrl: 'NewGame.component.html',
	providers: [GameService]
})	

export class NewGameComponent implements OnInit {
	actualGame: Game;
	constructor(private gameService: GameService) { }

	ngOnInit() {
		// this.GameService.getList().subscribe((res) => {
		// 	this.Games = res;
		// });
	}

	startGame()
	{
		this.gameService.newGame().subscribe((res) => this.actualGame = res);
		console.log(this.actualGame);
	}
}