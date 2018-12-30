import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { Game } from './Game.model';

@Injectable()
export class GameService {
	constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

	getList(): Observable<Game[]> {
		return this.http.get( this.baseUrl + '/api/list').map(res => res.json() as Game[]);
	}

	newGame():Observable<Game> {
		return this.http.post(this.baseUrl + "api/Game/PostGame",{})
		.map(res => res.json() as Game);
	}
}