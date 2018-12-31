import { Component, OnInit } from '@angular/core';
import { GameService } from '../NewGame/shared/Game.service';
import { ActivatedRoute } from '@angular/router';
import { Game } from '../NewGame/shared/Game.model';

@Component({
	moduleId: module.id,
	selector: 'Scores',
	templateUrl: './Scores.component.html',
	styleUrls: ['./Scores.component.css'],
	providers: [GameService]
})

export class ScoresComponent implements OnInit {
	scores: any[] = [];
	constructor(private gameService: GameService, private route: ActivatedRoute){}

	ngOnInit() {
		this.route.queryParams.subscribe(params => {
		
			this.gameService.get(params['gameId'])
						.subscribe(res => {
								let game:Game = res[0] as Game;
								let p1wins = game.rounds
												.filter(r => r.roundWinner == game.playerOneName)
												.length;
								let p2wins = game.rounds
												.filter(r => r.roundWinner == game.playerTwoName)
												.length;
								  this.scores.push({ "player": game.playerOneName, points: p1wins});
								  this.scores.push({ "player": game.playerTwoName, points: p2wins});
						});
		  })
	 }
}