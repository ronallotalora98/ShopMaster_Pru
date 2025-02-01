import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RoleService } from 'src/app/shared/service/role.service';

@Component({
  selector: 'app-card-table-roles',
  standalone: true,
  imports:[FormsModule, CommonModule],
  templateUrl: './card-table-roles.component.html',
  styleUrls: ['./card-table-roles.component.scss']
})
export class CardTableRolesComponent implements OnInit {

tituloTable: string = 'Listado de Roles';
roleData:any[]= [];
 data = [
  ]



  constructor(private roleService: RoleService,
    private router: Router,
  ) { }

  ngOnInit() {
    // this.cilindoService.getData().subscribe((res: any[]) => {
    //   // console.log(res);
    //   this.data = res.map((item, index) => ({
    //     ...item,
    //     position: index + 1  // Agregamos la posición (index + 1 para hacerlo 1-indexed)
    //   }));;
    // })

  }

  goToVerDetalle(id:number) {

  }

}


