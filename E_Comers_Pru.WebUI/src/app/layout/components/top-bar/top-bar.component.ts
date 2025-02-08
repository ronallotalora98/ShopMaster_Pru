import { AfterViewInit, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UserDto } from 'src/app/shared/Models/autg.model';
// import { FeatherModule } from 'angular-feather';

@Component({
  selector: 'app-top-bar',
  standalone: true,
  imports: [],
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.scss']
})
export class TopBarComponent implements OnInit {

  userDto: UserDto = { id: 0, name: '', email: '' };

  constructor() {

  }

  ngOnInit(): void {
    this.getDataUser();
  }

  getDataUser() {
    const userJson = localStorage.getItem('user');
    if (userJson) {
      this.userDto = JSON.parse(userJson) as UserDto;
    }
  }

}
