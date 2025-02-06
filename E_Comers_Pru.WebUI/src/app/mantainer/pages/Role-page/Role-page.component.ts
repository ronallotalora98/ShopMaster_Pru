import { Component, OnInit } from '@angular/core';
import { CardTableRolesComponent } from '../../components/card-table-roles/card-table-roles.component';
import { CardCreateRoleComponent } from '../../components/card-create-role/card-create-role.component';
import { IResponseVM } from 'src/app/shared/Models/response.api';
import { RoleDto } from '../../models/role.model';
import { RoleService } from 'src/app/shared/service/role.service';

@Component({
  selector: 'app-Role-page',
  standalone: true,
  imports: [CardTableRolesComponent, CardCreateRoleComponent],
  providers:[RoleService],
  templateUrl: './Role-page.component.html',
  styleUrls: ['./Role-page.component.scss']
})
export class RolePageComponent implements OnInit {

  roleData: RoleDto[] = [];

  constructor(private roleService: RoleService) { }

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {

    this.roleService.getRoles()
      .subscribe({
        next: (response: IResponseVM<RoleDto[]>) => {
          if (!response.isError) {
            if (response.result) {
              const data = response.element as RoleDto[];
              this.roleData = data;
            }
          }
        },
        error: (error: any) => {
          // this.loadService = false;
        },
        complete: () => {
          // this.loadService = false;
        }
      })
  }

}
