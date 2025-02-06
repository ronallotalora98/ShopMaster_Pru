import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequestVM } from 'src/app/shared/Models/autg.model';
import { LoginService } from 'src/app/shared/service/login.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginRequestVM: LoginRequestVM = {
    username: '',
    password: ''
  }
  passwordFieldType: string = 'password';
  isLoading: boolean = false;
  error: string | null = null

  constructor(private loginService: LoginService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  ;

  togglePasswordVisibility() {
    this.passwordFieldType = this.passwordFieldType === 'password' ? 'text' : 'password';
  }

  login() {
    console.log(this.loginRequestVM);
    this.router.navigate(['/home']);
    return;
    this.loginService.login(this.loginRequestVM).subscribe(
      () => {
        this.isLoading = false;
        this.router.navigate(['/']); // Redirige a la página principal o a otra protegida
      },
      error => {
        this.isLoading = false;
        this.error = 'Credenciales incorrectas. Inténtalo de nuevo.';
      }
    );
  }
}
