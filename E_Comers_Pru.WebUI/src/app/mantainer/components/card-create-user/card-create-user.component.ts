import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RoleService } from 'src/app/shared/service/role.service';
import { UserService } from 'src/app/shared/service/user.service';
import { RoleDto } from '../../models/role.model';
import Swal from 'sweetalert2';
import { UserDto } from '../../models/user.model';
import { IResponseVM } from 'src/app/shared/Models/response.api';

@Component({
  selector: 'app-card-create-user',
  standalone:true,
  imports:[CommonModule, ReactiveFormsModule, HttpClientModule],
  templateUrl: './card-create-user.component.html',
  styleUrls: ['./card-create-user.component.scss']
})
export class CardCreateUserComponent implements OnInit {

  userForm: FormGroup;
  isSubmitted: boolean = false;
  roleSelect: RoleDto[] = [];
  @Output() productSave = new EventEmitter<void>();

  constructor(private fb: FormBuilder,
    private userService: UserService,
    private roleService: RoleService
  ) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required],
      rolId: [0, Validators.required]
    });
  }

  ngOnInit() {
    this.getRoles();
  }

  getRoles() {
    this.roleService.getRoles()
      .subscribe({
        next: (response: IResponseVM<RoleDto[]>) => {
          if (!response.isError) {
            if (response.result) {
              const data = response.element as RoleDto[];
              this.roleSelect = data;
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

  clearField(fieldName: string) {
    this.userForm.get(fieldName)?.setValue('');
  }

  clearFields() {
    this.userForm.reset();
    this.isSubmitted = false; // Reset submission status
  }

  onSubmit() {
    this.isSubmitted = true;
    if (this.userForm.valid) {
      this.userService.createUser(this.userForm.value).subscribe(
        (newProduct: UserDto) => {

          this.productSave.emit();

          Swal.fire({
            title: `Usuario Creada Correctamente`,
            text: `el Usuario se ha creado correctamente`,
            icon: 'success',
            confirmButtonText: 'Aceptar'
          });

          this.userForm.reset();
          this.isSubmitted = false;
        },
        error => console.error(error)
      );
    }
  }


}
