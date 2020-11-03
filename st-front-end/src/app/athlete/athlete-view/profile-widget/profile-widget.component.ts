import { Component, OnInit } from '@angular/core';
import {Athlete} from '../../../models/athlete.model';

@Component({
  selector: 'app-profile-widget',
  templateUrl: './profile-widget.component.html',
  styleUrls: ['./profile-widget.component.css']
})
export class ProfileWidgetComponent implements OnInit {
  user: Athlete = new Athlete(
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

  constructor() { }

  ngOnInit(): void {
  }

}
