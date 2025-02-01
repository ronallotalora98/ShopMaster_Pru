import { Component, OnInit } from '@angular/core';
import { CardTableRolesComponent } from '../../components/card-table-roles/card-table-roles.component';

@Component({
  selector: 'app-Role-page',
  standalone: true,
  imports:[CardTableRolesComponent],
  templateUrl: './Role-page.component.html',
  styleUrls: ['./Role-page.component.scss']
})
export class RolePageComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
