import { Component, OnInit } from '@angular/core';
import { CardTableCategoryComponent } from '../../components/card-table-category/card-table-category.component';
import { CardCreateCategoryComponent } from '../../components/card-create-category/card-create-category.component';

@Component({
  selector: 'app-category-page',
  standalone: true,
  imports:[CardTableCategoryComponent, CardCreateCategoryComponent],
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.scss']
})
export class CategoryPageComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
