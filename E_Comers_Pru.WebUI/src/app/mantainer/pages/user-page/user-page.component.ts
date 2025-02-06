import { Component, OnInit } from '@angular/core';
import { CardCreateUserComponent } from '../../components/card-create-user/card-create-user.component';
import { CardTableUserComponent } from "../../components/card-table-user/card-table-user.component";
import { UserService } from 'src/app/shared/service/user.service';
import { UserDto } from '../../models/user.model';
import { IResponseVM } from 'src/app/shared/Models/response.api';

@Component({
  selector: 'app-user-page',
  standalone: true,
  imports: [CardCreateUserComponent, CardTableUserComponent],
  providers: [UserService],
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {

  userData: UserDto[] = [];
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getUsers()
  }
  getUsers() {
    this.userService.getUser()
      .subscribe({
        next: (response: IResponseVM<UserDto[]>) => {
          if (!response.isError) {
            if (response.result) {
              const data = response.element as UserDto[];
              this.userData = data;
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
