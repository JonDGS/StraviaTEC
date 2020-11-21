import {Component, OnInit, ViewChild} from '@angular/core';
import {Group} from '../../../models/group.model';
import {OrganizerService} from '../../organizer.service';
import {NgForm} from '@angular/forms';
import {Race} from '../../../models/race.model';

@Component({
  selector: 'app-organizer-groups',
  templateUrl: './organizer-groups.component.html',
  styleUrls: ['./organizer-groups.component.css']
})

/**
 * This class holds all the related information to the groups of the organizer view. It holds a list of
 * the created groups of the current organizer, a form for adding a new group and section for editing and
 * deleting the groups
 */
export class OrganizerGroupsComponent implements OnInit {
  @ViewChild('newGroup') groupForm: NgForm;
  groups: Group[];

  constructor(private oService: OrganizerService) { }

  ngOnInit(): void {
    this.groups = this.oService.myCreatedGroups;
  }

  /**
   * This method is called when  a new group is created
   */
  addGroup(): void {
    //crear el objeto
    let object = {}
    //enviar el post
    this.oService.postGroup(object);
    console.log(this.groupForm);
  }

  /**
   * This method is called when a group from the group list is deleted
   * @param group to delete
   */
  onDeleteGroup(group: Group): void {
  }
}
