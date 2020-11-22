import { ServerService } from './../../../server.service';
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
  groups: any;

  constructor(private oService: OrganizerService,private server: ServerService) { }

  ngOnInit(): void {
    this.setGroups();
    
  }

  setGroups(){
    this.groups = this.oService.myCreatedGroups;
    this.server.getGroupByToken().then(res => {
      this.groups = res;
    });
  }

  /**
   * This method is called when  a new group is created
   */
  addGroup(): void {
    //crear el objeto
    let object = {
      "name":this.groupForm.value.name
  }
    //enviar el post
    this.oService.postGroup(object);
    console.log(this.groupForm);
  }

  /**
   * This method is called when a group from the group list is deleted
   * @param group to delete
   */
  onDeleteGroup(groupID): void {
    this.server.deleteGroup(groupID);
    this.setGroups();
  }
}
