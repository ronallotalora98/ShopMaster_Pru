import { Component, OnInit } from '@angular/core';
import { CategoryDto } from '../../models/category.model';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CategoryService } from 'src/app/shared/service/category.service';
import { IResponseVM } from 'src/app/shared/Models/response.api';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-card-create-category',
  standalone: true,
  imports: [BrowserModule,CommonModule, ReactiveFormsModule],
  templateUrl: './card-create-category.component.html',
  styleUrls: ['./card-create-category.component.scss']
})
export class CardCreateCategoryComponent implements OnInit {

  categories: CategoryDto[] = [];
  categoryForm: FormGroup;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService
  ) {
    this.categoryForm = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required]
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
            this.categories = data;
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

  onSubmit() {
    if (this.categoryForm.valid) {
      this.categoryService.createCategory(this.categoryForm.value).subscribe(
        (newCategory: CategoryDto) => {
          this.categoryForm.reset();
        },
        error => console.error(error)
      );
    }
  }
}
