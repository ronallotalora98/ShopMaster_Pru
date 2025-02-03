/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CardTableProductComponent } from './card-table-product.component';

describe('CardTableProductComponent', () => {
  let component: CardTableProductComponent;
  let fixture: ComponentFixture<CardTableProductComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardTableProductComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardTableProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
