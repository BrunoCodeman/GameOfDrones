import { map } from 'rxjs/operators';

import { Game } from './Game.model';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Http } from '@angular/http';

@Injectable()
export class GameService {
	constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

	getList(): Observable<Game[]> {
		return this.http.get( this.baseUrl + '/api/list').pipe(map(res => res.json() as Game[]));
	}

	newGame():Observable<Game> {
		return this.http.post(this.baseUrl + "api/Game/PostGame",{}).pipe(
		map(res => res.json() as Game));
	}

	executeRound(game: Game): Observable<Game> 
    {
        return this.http.put(this.baseUrl + "api/Round/PutRound", game)
                        .pipe(map(res => res.json() as Game));
    }
}