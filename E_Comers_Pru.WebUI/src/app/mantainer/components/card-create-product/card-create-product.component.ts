import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductDto } from '../../models/product.model';
import Swal from 'sweetalert2';
import { ProductService } from 'src/app/shared/service/product.service';
import { CategoryDto } from '../../models/category.model';
import { CategoryService } from 'src/app/shared/service/category.service';
import { IResponseVM } from 'src/app/shared/Models/response.api';

@Component({
  selector: 'app-card-create-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule],
  providers: [ProductService, CategoryService],
  templateUrl: './card-create-product.component.html',
  styleUrls: ['./card-create-product.component.scss']
})
export class CardCreateProductComponent implements OnInit {

  productForm: FormGroup;
  isSubmitted: boolean = false;
  categoySelect: CategoryDto[] = [];
  @Output() productSave = new EventEmitter<void>();

  constructor(private fb: FormBuilder,
    private productService: ProductService,
    private categoryService: CategoryService
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(1)]],
      categoryId: [0, Validators.required],
      image: ['', Validators.required],
      inventory: [0, [Validators.required, Validators.min(1)]]
    });
  }

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getCategories()
      .subscribe({
        next: (response: IResponseVM<CategoryDto[]>) => {
          if (!response.isError) {
            if (response.result) {
              const data = response.element as CategoryDto[];
              this.categoySelect = data;
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
    this.productForm.get(fieldName)?.setValue('');
  }

  clearFields() {
    this.productForm.reset();
    this.isSubmitted = false; // Reset submission status
  }

  onSubmit() {
    this.isSubmitted = true;
    if (this.productForm.valid) {
      this.productService.createProduct(this.productForm.value).subscribe(
        (newProduct: ProductDto) => {

          this.productSave.emit();

          Swal.fire({
            title: `Producto Creada Correctamente`,
            text: `el Producto se ha creado correctamente`,
            icon: 'success',
            confirmButtonText: 'Aceptar'
          });

          this.productForm.reset();
          this.isSubmitted = false;
        },
        error => console.error(error)
      );
    }
  }

}
