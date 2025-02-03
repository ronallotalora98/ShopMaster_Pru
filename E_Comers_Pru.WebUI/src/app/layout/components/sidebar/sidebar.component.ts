import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
// import { FeatherModule } from 'angular-feather';
import { IMenuItem } from 'src/app/shared/Models/layout.model';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports:[RouterModule, CommonModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  activeItem = '/';
  loadMenu = true;
  menuItems = [
    {
      to: '/home',
      label: 'Inicio',
      icon: '././../../../assets/Icons/Malta/inicio_lineal.svg',
      activeIcon: 'assets/inicio_lleno.svg',
      key: 'Inicio',
    },
    {
      to: '/#',
      label: 'Mantenedores',
      icon: '././../../../assets/Icons/Malta/apps_lineal.svg',
      activeIcon: 'assets/inicio_lleno.svg',
      key: 'Inicio',
      subItems: [
        {
          to: '/mantenedores/producto',
          label: 'Productos',
          icon: '././../../../assets/Icons/Malta/Ver_grilla_lineal.svg',
          activeIcon: '././../../../assets/Icons/Malta/Ver_grilla_lineal.svg',
          key: 'Productos',
        },
        {
          to: '/mantenedores/categoria',
          label: 'Categorias',
          icon: '././../../../assets/Icons/Malta/componentes_lineal.svg',
          activeIcon: '././../../../assets/Icons/Malta/componentes_lineal.svg',
          key: 'Categorias',
        },
        {
          to: '/mantenedores/promocion',
          label: 'Promociones',
          icon: '.././../../../assets/Icons/Malta/servicios_financieros_lineal.svg',
          activeIcon: '.././../../../assets/Icons/Malta/servicios_financieros_lineal.svg',
          key: 'Promociones',
        },
        {
          to: '/mantenedores/rol',
          label: 'Roles',
          icon: '././../../../assets/Icons/Malta/docente_lineal.svg',
          activeIcon: '././../../../assets/Icons/Malta/docente_lineal.svg',
          key: 'Roles',
        },
        {
          to: '/mantenedores/usuario',
          label: 'Usuarios',
          icon: '././../../../assets/Icons/Malta/ficha_estudiante_lineal.svg',
          activeIcon: '././../../../assets/Icons/Malta/ficha_estudiante_lineal.svg',
          key: 'Usuarios',
        }
      ]
    }
  ];
  constructor() { }

  ngOnInit() {
  }
}
