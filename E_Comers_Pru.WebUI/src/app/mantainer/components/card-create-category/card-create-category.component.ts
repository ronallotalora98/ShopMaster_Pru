import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CategoryDto } from '../../models/category.model';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CategoryService } from 'src/app/shared/service/category.service';
import { IResponseVM } from 'src/app/shared/Models/response.api';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-card-create-category',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule],
  providers: [CategoryService],
  templateUrl: './card-create-category.component.html',
  styleUrls: ['./card-create-category.component.scss']
})
export class CardCreateCategoryComponent implements OnInit {

  categoryForm: FormGroup;
  isSubmitted: boolean = false;

  @Output() categorySave = new EventEmitter<void>();

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService
  ) {
    this.categoryForm = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required]
    });
  }

  ngOnInit() {
  }


  clearField(fieldName: string) {
    this.categoryForm.get(fieldName)?.setValue('');
  }

  clearFields() {
    this.categoryForm.reset();
    this.isSubmitted = false; // Reset submission status
  }

  onSubmit() {
    this.isSubmitted = true;
    if (this.categoryForm.valid) {
      this.categoryService.createCategory(this.categoryForm.value).subscribe(
        (newCategory: CategoryDto) => {

          this.categorySave.emit();

          Swal.fire({
            title: `Categoria Creada Correctamente`,
            text: `La Categoria se ha creado correctamente`,
            icon: 'success',
            confirmButtonText: 'Aceptar'
          });

          this.categoryForm.reset();
          this.isSubmitted = false;
        },
        error => console.error(error)
      );
    }
  }
}
