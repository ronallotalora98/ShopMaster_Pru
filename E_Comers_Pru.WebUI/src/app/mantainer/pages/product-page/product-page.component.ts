import { Component, OnInit } from '@angular/core';
import { CardCreateProductComponent } from '../../components/card-create-product/card-create-product.component';
import { CardTableProductComponent } from '../../components/card-table-product/card-table-product.component';
import { ProductService } from 'src/app/shared/service/product.service';
import { IResponseVM } from 'src/app/shared/Models/response.api';
import { ProductDto } from '../../models/product.model';

@Component({
  selector: 'app-product-page',
  standalone: true,
  imports: [CardCreateProductComponent, CardTableProductComponent],
  providers: [ProductService],
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.scss']
})
export class ProductPageComponent implements OnInit {

  productDto: ProductDto[] = []
  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {

    this.productService.getProducts()
      .subscribe({
        next: (response: IResponseVM<ProductDto[]>) => {
          console.log(response)
          if (!response.isError) {
            if (response.result) {
              const data = response.element as ProductDto[];
              this.productDto = data;
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
