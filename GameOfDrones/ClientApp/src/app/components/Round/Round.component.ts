import { Component, OnInit, Input } from '@angular/core';

import { Round } from './shared/Round.model';
import { GameService } from '../NewGame/shared/Game.service';
import { Game } from '../NewGame/shared/Game.model';
import { ActivatedRoute } from '@angular/router';

@Component({
	moduleId: module.id,
	selector: 'Round',
	templateUrl: 'Round.component.html',
	providers: [GameService]
})

export class RoundComponent implements OnInit {
	@Input() runningGame: Game ;
	player: string;
	constructor(private route: ActivatedRoute, private service: GameService) { }

	ngOnInit() {
		this.route.queryParams.subscribe(params => {
		
	    	this.player = params["player"];
		  console.log(params);
		  this.service.get(params['gameId']).subscribe(res => this.runningGame = res);
		  
		})
	}

	round()
	{
		this.service.executeRound(this.runningGame).subscribe(res => this.runningGame = res);
	}
}