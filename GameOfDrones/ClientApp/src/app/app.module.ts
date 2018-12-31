import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NewGameComponent } from './components/NewGame/NewGame.component';
import { HttpModule } from '@angular/http';
import { RoundComponent } from './components/Round/Round.component';
import { ScoresComponent } from './components/Scores/Scores.component';

@NgModule({
  declarations: [
    AppComponent,
    NewGameComponent,
    RoundComponent,
    ScoresComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo:"newgame", pathMatch: 'full' },
      { path: 'newgame', component: NewGameComponent},
      { path: 'round', component: RoundComponent,runGuardsAndResolvers: 'always',},
      { path: 'scores', component: ScoresComponent},
    ], {onSameUrlNavigation: 'reload'})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
