import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
// import { FeatherModule } from 'angular-feather';
import { IMenuItem } from 'src/app/shared/Models/layout.model';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports:[RouterModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
}
