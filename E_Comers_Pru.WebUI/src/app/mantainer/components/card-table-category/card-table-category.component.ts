import { Component, Input, OnInit } from '@angular/core';
import { CategoryDto } from '../../models/category.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-card-table-category',
  standalone: true,
  imports:[CommonModule],
  templateUrl: './card-table-category.component.html',
  styleUrls: ['./card-table-category.component.scss']
})
export class CardTableCategoryComponent implements OnInit {

  @Input() categoryData: CategoryDto[] = [
    {id: 1, name:'Tecnologa', code:'TEC'}
  ];
  constructor() { }

  ngOnInit() {
  }

  seeCategy(id:number){

  }
  editCategory(id:number){

  }

  deleteCategory(id:number){

  }


}
