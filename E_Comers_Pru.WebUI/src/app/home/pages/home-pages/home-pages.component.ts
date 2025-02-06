import { Component, OnInit } from '@angular/core';
import { CardItemProductComponent } from '../../components/card-item-product/card-item-product.component';
import { CardSearcherComponent } from '../../components/card-searcher/card-searcher.component';

@Component({
  selector: 'app-home-pages',
  standalone: true,
  imports:[CardItemProductComponent, CardSearcherComponent],
  templateUrl: './home-pages.component.html',
  styleUrls: ['./home-pages.component.scss']
})
export class HomePagesComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
