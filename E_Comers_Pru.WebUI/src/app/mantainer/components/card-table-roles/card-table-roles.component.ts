import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RoleService } from 'src/app/shared/service/role.service';
import { RoleDto } from '../../models/role.model';

@Component({
  selector: 'app-card-table-roles',
  standalone: true,
  imports:[FormsModule, CommonModule],
  templateUrl: './card-table-roles.component.html',
  styleUrls: ['./card-table-roles.component.scss']
})
export class CardTableRolesComponent implements OnInit {

tituloTable: string = 'Listado de Roles';
@Input() roleData:RoleDto[]= [
  {id: 1, name:'Administrador', code:'Admin'}
];



  constructor(private roleService: RoleService,
    private router: Router,
  ) { }

  ngOnInit() {
  }

  seeRole(id:number){

  }
  editRole(id:number){

  }

  deleteRole(id:number){

  }

}


