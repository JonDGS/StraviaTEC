import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {RouterModule, Routes} from '@angular/router';
import { HomeViewComponent } from './home/home-view/home-view.component';
import { AthleteViewComponent } from './athlete/athlete-view/athlete-view.component';
import { OrganizerViewComponent } from './organizer/organizer-view/organizer-view.component';


const appRoutes: Routes = [
  { path: '', component: HomeViewComponent },
  { path: 'athlete', component: AthleteViewComponent },
  { path: 'organizer', component: OrganizerViewComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeViewComponent,
    AthleteViewComponent,
    OrganizerViewComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
