import { Component, Input, OnInit } from '@angular/core';
import { UserDto } from '../../models/user.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-card-table-user',
  standalone:true,
  imports:[CommonModule],
  templateUrl: './card-table-user.component.html',
  styleUrls: ['./card-table-user.component.scss']
})
export class CardTableUserComponent implements OnInit {

@Input() userData:UserDto[]= [
  {id: 1, name:'Administrador', email:'Admin', rolId:1, password:''}
];



  constructor(
  ) { }

  ngOnInit() {
  }

  seeUser(id:number){

  }
  editUser(id:number){

  }

  deleteUser(id:number){

  }

}
