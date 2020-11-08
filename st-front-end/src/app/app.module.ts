import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {RouterModule, Routes} from '@angular/router';
import { HomeViewComponent } from './home/home-view/home-view.component';
import { AthleteViewComponent } from './athlete/athlete-view/athlete-view.component';
import { OrganizerViewComponent } from './organizer/organizer-view/organizer-view.component';
import { RegisterComponent } from './home/home-view/register/register.component';
import { LoginComponent } from './home/home-view/login/login.component';
import { FormsModule } from '@angular/forms';
import { ActivityManagementComponent } from './athlete/athlete-view/activity-management/activity-management.component';
import { ProfileWidgetComponent } from './athlete/athlete-view/profile-widget/profile-widget.component';
import { NavbarComponent } from './athlete/athlete-view/navbar/navbar.component';
import { AthleteSettingsComponent } from './athlete/athlete-view/athlete-settings/athlete-settings.component';

import {HttpClientModule } from '@angular/common/http';
import { AthleteChallengesComponent } from './athlete/athlete-view/athlete-challenges/athlete-challenges.component';

const appRoutes: Routes = [
  { path: '', component: HomeViewComponent },
  { path: 'athlete', component: AthleteViewComponent },
  { path: 'athlete/settings', component: AthleteSettingsComponent},
  { path: 'athlete/challenges', component: AthleteChallengesComponent},
  { path: 'organizer', component: OrganizerViewComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeViewComponent,
    AthleteViewComponent,
    OrganizerViewComponent,
    RegisterComponent,
    LoginComponent,
    ActivityManagementComponent,
    ProfileWidgetComponent,
    NavbarComponent,
    AthleteSettingsComponent,
    AthleteChallengesComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
