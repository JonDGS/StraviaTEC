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
  @ViewChild('updateGroupForm') updateForm: NgForm;
  groups: any;
  isUpdateForm: boolean;
  groupToUpdate: Group;
  ugName: string;
  ugAdmin: string;



  constructor(private oService: OrganizerService,private server: ServerService) {this.isUpdateForm = false; }

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
    // Crear el objeto
    let object = {
      "name": this.groupForm.value.name
    };
    // Enviar el post
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

  /**
   * This method is called when the update button is called. This method sets the boolean var
   * for showing the update form and also sets a series of variables that fill the update form
   * @param group to update
   */
  onUpdateGroup(group: Group): void {
    this.groupToUpdate = group;
    this.isUpdateForm = true;
    this.ugName = this.groupToUpdate.name;
    this.ugAdmin = this.groupToUpdate.admin;
  }

  /**
   * This method is called when the update form is submitted
   */
  updateGroup(): void {
    this.isUpdateForm = false;
  }
}


