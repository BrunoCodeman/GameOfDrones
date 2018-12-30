import { Component, OnInit, Input } from '@angular/core';

import { Round } from './shared/Round.model';
import { GameService } from '../NewGame/shared/Game.service';

@Component({
	moduleId: module.id,
	selector: 'PlayerTurn',
	templateUrl: 'PlayerTurn.component.html',
	providers: [GameService]
})

export class PlayerTurnComponent implements OnInit {
	@Input() Round: Round ;
	@Input() Player: string;
	constructor() { }

	ngOnInit() {}

	round()
	{

	}
}