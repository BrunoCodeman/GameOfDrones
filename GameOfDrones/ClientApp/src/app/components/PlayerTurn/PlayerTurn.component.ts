import { Component, OnInit, Input } from '@angular/core';

import { PlayerTurn } from './shared/PlayerTurn.model';
import { PlayerTurnService } from './shared/PlayerTurn.service';

@Component({
	moduleId: module.id,
	selector: 'PlayerTurn',
	templateUrl: 'PlayerTurn.component.html',
	providers: [PlayerTurnService]
})

export class PlayerTurnComponent implements OnInit {
	PlayerTurn: PlayerTurn[] = [];
	@Input() Player: string;
	constructor(private PlayerTurnService: PlayerTurnService) { }

	ngOnInit() {
		this.PlayerTurnService.getList().subscribe((res) => {
			this.PlayerTurn = res;
		});
	}
}