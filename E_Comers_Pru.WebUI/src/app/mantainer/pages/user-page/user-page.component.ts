import { Component, OnInit } from '@angular/core';
import { CardCreateUserComponent } from '../../components/card-create-user/card-create-user.component';
import { CardTableUserComponent } from "../../components/card-table-user/card-table-user.component";

@Component({
  selector: 'app-user-page',
  standalone: true,
  imports: [CardCreateUserComponent, CardTableUserComponent],
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
