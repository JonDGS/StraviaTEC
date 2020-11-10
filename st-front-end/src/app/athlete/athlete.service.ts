import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Athlete} from '../models/athlete.model';
import {Challenge} from '../models/challenge.model';

@Injectable({
  providedIn: 'root'
})
export class AthleteService {
  // Used for storing the information of the current user
  currentUser: Athlete = new Athlete(
    'Alvaro',
    'Vargas',
    'Costa Rican',
    117730762,
    20,
    '3/4/2000',
    'Costa Rica',
    'Heredia',
    'Belen',
    'avargasm',
    'https://www.hola.com/imagenes/cocina/recetas/20200617170335/mac-and-cheese/0-837-58/mac-cheese-adobe-m.jpg',
    '123abc');

  // Used for checking if the athlete home page view was changed (/athlete), mainly works for activating the return button
  // on the athlete-navbar
  onChangedView = false;

  challenges = [
    new Challenge( '1', 'West Challenge', '30 days', 'Running', 'Fondo?', 60, ['None']),
    new Challenge( '2', 'North Challenge', '20 days', 'Swimming', 'Fondo?', 35, ['None']),
    new Challenge( '3', 'South Challenge', '10 days', 'Kayaking', 'Fondo?', 40, ['None'])
  ];

  constructor(private http: HttpClient) {

  }

}
