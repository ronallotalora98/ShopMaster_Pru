import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-card-table',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './card-table.component.html',
  styleUrls: ['./card-table.component.scss']
})
export class CardTableComponent implements OnInit {

  selectedRows: string[] = [];
  entriesToShow: number = 10;
  filter: string = '';
  currentPage: number = 1;
  data: any[] = [];
  headerTable: string[] = [];
  excludeLastColumn: boolean = false

  constructor() { }

  @Input() title: string = 'Titulo Tabla'
  @Input() description: string = 'Una Descripcion de la Tabla'

  ngOnInit() {
  }

  handleFilterChange(value: string) {
    this.filter = value;
  }

  get filteredData() {
    return this.data.filter(item =>
      Object.values(item).some(val =>
        val && val.toString().toLowerCase().includes(this.filter.toLowerCase())
      )
    );
  }

  get indexOfLastEntry() {
    return this.currentPage * this.entriesToShow;
  }

  get indexOfFirstEntry() {
    return this.indexOfLastEntry - this.entriesToShow;
  }

  get currentEntries() {
    return this.filteredData.slice(this.indexOfFirstEntry, this.indexOfLastEntry);
  }

  get totalPages() {
    return Math.ceil(this.filteredData.length / this.entriesToShow);
  }

  handleNextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }

  handlePrevPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  handleEntriesChange(event: any) {
    this.entriesToShow = Number(event.target.value);
    this.currentPage = 1;
  }

  handleRowSelection(id: string) {
    const isSelected = this.selectedRows.includes(id);
    if (isSelected) {
      this.selectedRows = this.selectedRows.filter(rowId => rowId !== id);
    } else {
      this.selectedRows.push(id);
    }
  }

  setCurrentPage(page: number) {
    if (page > 0 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }
  getMinIndex(lastEntryIndex: number, length: number) {
    return Math.min(lastEntryIndex, length);
  }

  objectKeys(obj: any) {
    return Object.keys(obj);
  }
  onClickDelete(id: number) {

  }

  onClickEditar(id: number) {

  }
}
