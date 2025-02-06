import { Component, OnInit } from '@angular/core';
import { CardTableCategoryComponent } from '../../components/card-table-category/card-table-category.component';
import { CardCreateCategoryComponent } from '../../components/card-create-category/card-create-category.component';
import { CategoryDto } from '../../models/category.model';
import { CategoryService } from 'src/app/shared/service/category.service';
import { IResponseVM } from 'src/app/shared/Models/response.api';

@Component({
  selector: 'app-category-page',
  standalone: true,
  imports:[CardTableCategoryComponent, CardCreateCategoryComponent],
  providers:[CategoryService],
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.scss']
})
export class CategoryPageComponent implements OnInit {

  categoryData:CategoryDto[] = [];

  constructor( private categoryService: CategoryService) { }

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
            this.categoryData = data;
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
