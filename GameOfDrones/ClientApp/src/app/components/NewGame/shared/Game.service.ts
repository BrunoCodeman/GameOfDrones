import { map } from 'rxjs/operators';

import { Game } from './Game.model';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Http, Headers } from '@angular/http';
import { HttpHeaders, HttpClient } from '@angular/common/http';


const headers = new HttpHeaders().set('Content-Type','application/json; charset=utf-8;') ;
@Injectable()
export class GameService {
	games: Observable<Game[]>;
	
	constructor(private http: HttpClient , @Inject('BASE_URL') private baseUrl: string) { }

	get(gameId: number): Observable<Game[]> {
		return this.http.get<Game[]>( this.baseUrl + 'api/Game/GetGame/?gameId='+ gameId);
	}

	newGame(game: Game):Observable<Game> {

		return this.http.post<Game>(this.baseUrl + "api/Game/PostGame", 
							game, {headers:headers, responseType: 'json'});
	}

	executeRound(game: Game): Observable<Game> 
    {
		console.log(game.rounds);
		return this.http.put<Game>(this.baseUrl + "api/Game/PutGame", 
							game, {headers:headers, responseType: 'json'});
    }
}