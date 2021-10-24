import { Component, OnInit } from '@angular/core';

import { SalesPerson } from '../interfaces/sales-person';
import { SalesPersonService } from '../services/sales-person.service';

@Component({
  selector: 'app-sales-person',
  templateUrl: './sales-person.component.html',
  styleUrls: ['./sales-person.component.scss']
})
export class SalesPersonComponent implements OnInit {

  salesPeople: SalesPerson[] = [];

  constructor(private salesPersonService: SalesPersonService) {
    salesPersonService.salesPeopleUpdated.subscribe( () => this.getSalesPeople());
  }

  ngOnInit(): void {
    this.getSalesPeople();
  }

  getSalesPeople(): void {
    this.salesPersonService.getSalesPeople()
      .subscribe(salesPeople => this.salesPeople = salesPeople);
  }

}
