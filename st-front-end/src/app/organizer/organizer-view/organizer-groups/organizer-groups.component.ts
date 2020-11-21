import {Component, OnInit, ViewChild} from '@angular/core';
import {Group} from '../../../models/group.model';
import {OrganizerService} from '../../organizer.service';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-organizer-groups',
  templateUrl: './organizer-groups.component.html',
  styleUrls: ['./organizer-groups.component.css']
})
export class OrganizerGroupsComponent implements OnInit {
  @ViewChild('newGroup') groupForm: NgForm;
  groups: Group[];

  constructor(private oService: OrganizerService) { }

  ngOnInit(): void {
    this.groups = this.oService.myCreatedGroups;
  }

  addGroup(): void {
    //crear el objeto
    let object = {}
    //enviar el post
    this.oService.postGroup(object);
    console.log(this.groupForm);
  }
}
