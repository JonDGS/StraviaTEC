import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeViewComponent } from './home/home-view/home-view.component';
import { AthleteViewComponent } from './athlete/athlete-view/athlete-view.component';
import { OrganizerViewComponent } from './organizer/organizer-view/organizer-view.component';
import { RegisterComponent } from './home/home-view/register/register.component';
import { LoginComponent } from './home/home-view/login/login.component';
import { FormsModule } from '@angular/forms';
import { ActivityManagementComponent } from './athlete/athlete-view/activity-management/activity-management.component';
import { ProfileWidgetComponent } from './athlete/athlete-view/profile-widget/profile-widget.component';
import { NavbarComponent } from './athlete/athlete-view/athlete-navbar/athlete-navbar.component';
import { AthleteSettingsComponent } from './athlete/athlete-view/athlete-settings/athlete-settings.component';
import { SearchComponent } from './athlete/athlete-view/search/search.component';
import { SearchItemComponent } from './athlete/athlete-view/search/search-item/search-item.component';

import { HttpClientModule } from '@angular/common/http';
import { AthleteChallengesComponent } from './athlete/athlete-view/athlete-challenges/athlete-challenges.component';
import { AthleteChallengeItemComponent } from './athlete/athlete-view/athlete-challenges/athlete-challenge-item/athlete-challenge-item.component';
import { ParticipatingActivitiesComponent } from './athlete/athlete-view/participating-activities/participating-activities.component';
import { ParticipatingChallengesComponent } from './athlete/athlete-view/participating-activities/participating-challenges/participating-challenges.component';
import { ParticipatingRacesComponent } from './athlete/athlete-view/participating-activities/participating-races/participating-races.component';
import { ParticipatingGroupsComponent } from './athlete/athlete-view/participating-activities/participating-groups/participating-groups.component';
import { OrganizerNavbarComponent } from './organizer/organizer-view/organizer-navbar/organizer-navbar.component';
import { OrganizerSettingsComponent } from './organizer/organizer-view/organizer-settings/organizer-settings.component';


const appRoutes: Routes = [
  { path: '', component: HomeViewComponent },
  { path: 'athlete', component: AthleteViewComponent },
  { path: 'athlete/settings', component: AthleteSettingsComponent},
  { path: 'athlete/search', component: SearchComponent},
  { path: 'athlete/challenges', component: AthleteChallengesComponent},
  { path: 'organizer', component: OrganizerViewComponent },
  { path: 'organizer/settings', component: OrganizerSettingsComponent }
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
    AthleteChallengeItemComponent,
    SearchComponent,
    SearchItemComponent,
    ParticipatingActivitiesComponent,
    ParticipatingChallengesComponent,
    ParticipatingRacesComponent,
    ParticipatingGroupsComponent,
    OrganizerNavbarComponent,
    OrganizerSettingsComponent
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
