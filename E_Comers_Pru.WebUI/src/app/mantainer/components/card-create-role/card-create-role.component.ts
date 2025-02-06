import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RoleService } from 'src/app/shared/service/role.service';
import Swal from 'sweetalert2';
import { RoleDto } from '../../models/role.model';

@Component({
  selector: 'app-card-create-role',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule],
  providers: [RoleService],
  templateUrl: './card-create-role.component.html',
  styleUrls: ['./card-create-role.component.scss']
})
export class CardCreateRoleComponent implements OnInit {

  roleForm: FormGroup;
  isSubmitted: boolean = false;

  @Output() roleSave = new EventEmitter<void>();

  constructor(private fb: FormBuilder,
    private roleService: RoleService
  ) {
    this.roleForm = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required]
    });
  }

  ngOnInit() {
  }


  clearField(fieldName: string) {
    this.roleForm.get(fieldName)?.setValue('');
  }

  clearFields() {
    this.roleForm.reset();
    this.isSubmitted = false; // Reset submission status
  }

  onSubmit() {
    this.isSubmitted = true;
    if (this.roleForm.valid) {
      this.roleService.createRole(this.roleForm.value).subscribe(
        (newRole: RoleDto) => {

          this.roleSave.emit();

          Swal.fire({
            title: `Rol Creado Correctamente`,
            text: `el Rol se ha creado correctamente`,
            icon: 'success',
            confirmButtonText: 'Aceptar'
          });

          this.roleForm.reset();
          this.isSubmitted = false;
        },
        error => console.error(error)
      );
    }
  }
}
