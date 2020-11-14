import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrganizerService {
  /*
    Used for checking if the organizer home page view was changed (/organizer), mainly works for activating the return button
    on the organizer-navbar
   */
  changedView = false;

  constructor() { }
}
