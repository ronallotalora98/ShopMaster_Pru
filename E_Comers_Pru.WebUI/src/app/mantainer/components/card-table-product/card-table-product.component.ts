import { Component, Input, OnInit } from '@angular/core';
import { ProductDto } from '../../models/product.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-card-table-product',
  standalone:true,
  imports:[CommonModule],
  templateUrl: './card-table-product.component.html',
  styleUrls: ['./card-table-product.component.scss']
})
export class CardTableProductComponent implements OnInit {

  @Input() productData: ProductDto[] = [
    {id: 1, name:'Tecnologa', description:'',
      price:0,
      categoryId:0,
      image:'',
      inventory:0}
  ];
  constructor() { }

  ngOnInit() {
  }

  seeProduct(id:number){

  }
  editProduct(id:number){

  }

  deleteProduct(id:number){

  }

}
