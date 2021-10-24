import { Component, OnInit } from '@angular/core';

import { SalesGroup } from '../interfaces/sales-group';
import { SalesGroupService } from '../services/sales-group.service';

@Component({
  selector: 'app-sales-group',
  templateUrl: './sales-group.component.html',
  styleUrls: ['./sales-group.component.scss']
})
export class SalesGroupComponent implements OnInit {

  salesGroups: SalesGroup[] = [];

  constructor(
    private salesGroupService: SalesGroupService
  ) { }

  ngOnInit(): void {
    this.getSalesGroups();
  }

  getSalesGroups(): void {
    this.salesGroupService.getSalesGroups()
      .subscribe(salesGroups => this.salesGroups = salesGroups);
  }
}
